using Microsoft.EntityFrameworkCore.InMemory;
using Microsoft.EntityFrameworkCore;
using Server.Persistence;
using Server.Domain;

namespace Server.Tests.Common
{
    public class ContextFactory
    {
        // data for testing
        public static Guid[] fridgeModelGuids = new Guid[2] { Guid.NewGuid(), Guid.NewGuid() },
                fridgeGuids = new Guid[2] { Guid.NewGuid(), Guid.NewGuid() },
                productGuids = new Guid[2] { Guid.NewGuid(), Guid.NewGuid() },
                fridgeProductGuids = new Guid[2] { Guid.NewGuid(), Guid.NewGuid() };

        public static ServerDbContext Create()
        {
            var options = new DbContextOptionsBuilder<ServerDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var context = new ServerDbContext(options);
            context.Database.EnsureCreated();

            for (int i = 0; i < 5; i++)
            {
                fridgeModelGuids[i] = Guid.NewGuid();
                fridgeGuids[i] = Guid.NewGuid();
                productGuids[i] = Guid.NewGuid();
                fridgeProductGuids[i] = Guid.NewGuid();
            }

            context.FridgeModels.AddRange(new List<FridgeModel>()
            {
                    new FridgeModel() { Id = fridgeModelGuids[0], Name = "Bosch", Year = 2018 },
                    new FridgeModel() { Id = fridgeModelGuids[1], Name = "Whirpool", Year = 2017 },
            });

            context.Fridges.AddRange(new List<Fridge>()
            {
                    new Fridge() { Id = fridgeGuids[0], Name = "Top Freezer Refrigerator", OwnerName = "Kirill", FridgeModelId = fridgeModelGuids[0]},
                    new Fridge() { Id = fridgeGuids[1], Name = "French Door Refrigerator", OwnerName = "Egor", FridgeModelId = fridgeModelGuids[0]},
            });

            context.Products.AddRange(new List<Product>()
            {
                    new Product() { Id = productGuids[0], Name = "Cucumber", DefaultQuantity = 2},
                    new Product() { Id = productGuids[1], Name = "Egg", DefaultQuantity = 10},
            });

            context.FridgeProducts.AddRange(new List<FridgeProduct>()
            {
                    new FridgeProduct() { Id = fridgeProductGuids[0], FridgeId = fridgeGuids[0], ProductId = productGuids[0], Quantity = 5},
                    new FridgeProduct() { Id = fridgeProductGuids[1], FridgeId = fridgeGuids[0], ProductId = productGuids[1], Quantity = 0},
            });

            context.SaveChanges();
            return context;
        }

        public static void Destroy(ServerDbContext context)
        {
            context.Database.EnsureDeleted();
            context.Dispose();
        }
    }
}
