using Server.Domain;
using Microsoft.EntityFrameworkCore;

namespace Server.Application.Interfaces
{
    public interface IServerDbContext
    {
        public DbSet<Fridge> Fridges { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<FridgeModel> FridgeModels { get; set; }
        public DbSet<FridgeProduct> FridgeProducts { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
