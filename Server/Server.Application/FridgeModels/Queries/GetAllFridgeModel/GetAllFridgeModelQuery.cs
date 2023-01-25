using MediatR;
using Server.Application.FridgeModels.Queries.GetAllFridgeModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Application.FridgeModels.Queries.GetFridgeModel
{
    public class GetAllFridgeModelQuery : IRequest<FridgeModelListVm>
    {
    }
}
