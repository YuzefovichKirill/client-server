using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Server.Application.Interfaces;

namespace Server.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection
            services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DbConnectionString");

            services.AddDbContext<ServerDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });
            // doesn't work
            //services.AddScoped<IServerDbContext>(provider =>
            //    provider.GetService<IServerDbContext>());

            services.AddScoped<IServerDbContext, ServerDbContext>();
            return services;
        }

    }
}
