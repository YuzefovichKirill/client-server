using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Application.FridgeModels.Queries.GetFridgeModel
{
    public class FridgeModelListVm
    {
        public IList<FridgeModelDto> FridgeModels { get; set; }
    }
}
