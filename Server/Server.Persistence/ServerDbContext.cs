using Microsoft.EntityFrameworkCore;
using Server.Application.Interfaces;
using Server.Domain;
using Server.Persistence.EntityTypeConfigurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Persistence
{
    public class ServerDbContext : DbContext, IServerDbContext
    {
        public DbSet<Fridge> Fridges { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<FridgeModel> FridgeModels { get; set; }
        public DbSet<FridgeProduct> FridgeProducts { get; set; }

        public ServerDbContext(DbContextOptions<ServerDbContext> options)
            : base(options) { }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new FridgeConfiguration());
            builder.ApplyConfiguration(new FridgeProductConfiguration());
            builder.ApplyConfiguration(new FridgeModelConfiguration());
            builder.ApplyConfiguration(new ProductConfiguration());
            base.OnModelCreating(builder);
        }

    }
}
