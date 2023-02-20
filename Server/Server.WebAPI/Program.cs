using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Protocols;
using Server.Application;
using Server.Application.Common.Mappings;
using Server.Application.Interfaces;
using Server.Persistence;
using System;
using System.Reflection;
using Server.WebAPI.Middleware;
using Serilog;
using Serilog.Events;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace Server.WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
                .WriteTo.File("WebAppLog-.log", rollingInterval:
                    RollingInterval.Day)
                .CreateLogger();

            var builder = WebApplication.CreateBuilder(args);
            builder.Host.UseSerilog(Log.Logger);

            IServiceCollection services = builder.Services;

            services.AddAutoMapper(config =>
            {
                config.AddProfile(new AssemblyMappingProfile(Assembly.GetExecutingAssembly()));
                config.AddProfile(new AssemblyMappingProfile(typeof(IServerDbContext).Assembly));
            });

            ConfigurationManager config = builder.Configuration;
            services.AddApplication();
            services.AddPersistence(config);
            services.AddControllers();

            // Cross-origin resource sharing
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", policy =>
                {
                    policy.AllowAnyHeader();
                    policy.AllowAnyMethod();
                    policy.AllowAnyOrigin();
                });
            });

            services.AddTransient<IConfigureOptions<SwaggerGenOptions>,
                ConfigureSwaggerOptions>();

            services
                .AddAuthentication(config =>
                { 
                    config.DefaultAuthenticateScheme =
                        JwtBearerDefaults.AuthenticationScheme;
                    config.DefaultChallengeScheme = 
                        JwtBearerDefaults.AuthenticationScheme;        
                })
                .AddJwtBearer("Bearer", options =>
                {
                    options.Authority = "https://localhost:7088/";
                    options.Audience = "ServerWebAPI";
                    options.RequireHttpsMetadata = false;
                });

            services.AddAuthorization();

            services.AddSwaggerGen();


            // Configure
            var app = builder.Build();


            using (var scope = app.Services.CreateScope())
            {
                var serviceProvider = scope.ServiceProvider;
                try
                {
                    var context = serviceProvider.GetRequiredService<ServerDbContext>();
                    DbInitializer.Initialize(context);
                }
                catch (Exception exception)
                {
                    Log.Fatal(exception, "An error occured while app initialization");
                }
            }

            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TaskWebAPIServer v1"));

            app.UseCustomExceptionHandler();
            app.UseRouting();
            app.UseHttpsRedirection();
            app.UseCors("AllowAll");

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.Run();
        }
    }
}