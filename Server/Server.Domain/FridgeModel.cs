using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Domain
{
    public class FridgeModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }

        public List<Fridge> fridges = new();
    }
}
