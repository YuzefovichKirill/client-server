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
        }
    }
}
