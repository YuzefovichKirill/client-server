using Microsoft.EntityFrameworkCore;
using Server.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Persistence
{
    public class DbInitializer
    {
        public static void Initialize(ServerDbContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            Guid[] fridgeModelGuids = new Guid[5], 
                fridgeGuids = new Guid[5],
                productGuids = new Guid[5],
                fridgeProductGuids = new Guid[5];
            
            for (int i = 0; i < 5; i++)
            {
                fridgeModelGuids[i] = Guid.NewGuid();
                fridgeGuids[i] = Guid.NewGuid();
                productGuids[i] = Guid.NewGuid();
                fridgeProductGuids[i] = Guid.NewGuid();
            }

            if (!context.FridgeModels.Any() && !context.FridgeProducts.Any() &&
                !context.Fridges.Any() && !context.Products.Any())
            {
                context.FridgeModels.AddRange(new List<FridgeModel>() 
                {
                    new FridgeModel() { Id = fridgeModelGuids[0], Name = "Bosch", Year = 2018 },
                    new FridgeModel() { Id = fridgeModelGuids[1], Name = "Whirpool", Year = 2017 },
                    new FridgeModel() { Id = fridgeModelGuids[2], Name = "LG", Year = 2012 },
                    new FridgeModel() { Id = fridgeModelGuids[3], Name = "Maytag", Year = 2012 },
                    new FridgeModel() { Id = fridgeModelGuids[4], Name = "Samsung", Year = 2012 }
                });

                context.Fridges.AddRange(new List<Fridge>()
                {
                    new Fridge() { Id = fridgeGuids[0], Name = "Top Freezer Refrigerator", OwnerName = "Kirill", FridgeModelId = fridgeModelGuids[4]},
                    new Fridge() { Id = fridgeGuids[1], Name = "French Door Refrigerator", OwnerName = "Egor", FridgeModelId = fridgeModelGuids[3]},
                    new Fridge() { Id = fridgeGuids[2], Name = "800 Series", OwnerName = "Egor", FridgeModelId = fridgeModelGuids[0]},
                    new Fridge() { Id = fridgeGuids[3], Name = "Bottom Freezer Refrigerator", OwnerName = "Emanuel", FridgeModelId = fridgeModelGuids[1]},
                    new Fridge() { Id = fridgeGuids[4], Name = "190 L Single Door Refrigerator", OwnerName = "Mike", FridgeModelId = fridgeModelGuids[2]}
                });

                context.Products.AddRange(new List<Product>()
                {
                    new Product() { Id = productGuids[0], Name = "Cucumber", DefaultQuantity = 2},
                    new Product() { Id = productGuids[1], Name = "Egg", DefaultQuantity = 10},
                    new Product() { Id = productGuids[2], Name = "Tomato", DefaultQuantity = 5},
                    new Product() { Id = productGuids[3], Name = "Banana", DefaultQuantity = 6},
                    new Product() { Id = productGuids[4], Name = "Apple", DefaultQuantity = 2},
                });

                context.FridgeProducts.AddRange(new List<FridgeProduct>()
                {
                    new FridgeProduct() { Id = fridgeProductGuids[0], FridgeId = fridgeGuids[0], ProductId = productGuids[4], Quantity = 5},
                    new FridgeProduct() { Id = fridgeProductGuids[1], FridgeId = fridgeGuids[0], ProductId = productGuids[3], Quantity = 0},
                    new FridgeProduct() { Id = fridgeProductGuids[2], FridgeId = fridgeGuids[1], ProductId = productGuids[1], Quantity = 18},
                    new FridgeProduct() { Id = fridgeProductGuids[3], FridgeId = fridgeGuids[2], ProductId = productGuids[2], Quantity = 3},
                    new FridgeProduct() { Id = fridgeProductGuids[4], FridgeId = fridgeGuids[3], ProductId = productGuids[0], Quantity = 7}
                });

                context.SaveChanges();
            }
        }
    }
}
