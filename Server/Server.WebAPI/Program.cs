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

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.Run();
        }
    }
}