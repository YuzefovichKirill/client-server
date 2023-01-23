using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Domain
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int DefaultQuantity { get; set; }

        public List<FridgeProduct> fridgeProducts = new();
    }
}
