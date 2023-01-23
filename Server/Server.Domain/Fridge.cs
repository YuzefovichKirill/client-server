using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Domain
{
    public class Fridge
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string OwnerName { get; set; }

        [ForeignKey("FridgeModel")]
        public int FridgeModelId { get; set; }
        public FridgeModel FridgeModel { get; set; }

        public List<FridgeProduct> fridgeProducts = new();
    }
}
