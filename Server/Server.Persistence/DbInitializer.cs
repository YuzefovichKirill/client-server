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
            context.Database.EnsureCreated();

            if (!context.FridgeModels.Any())
            {
                context.FridgeModels.AddRange(new List<FridgeModel>() 
                {
                    new FridgeModel() { Id = Guid.NewGuid(), Name = "Bosch", Year = 2018 },
                    new FridgeModel() { Id = Guid.NewGuid(), Name = "LG", Year = 2012 }
                });

                context.SaveChanges();
            }
        }
    }
}
