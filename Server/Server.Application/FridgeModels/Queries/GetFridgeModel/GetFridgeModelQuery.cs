using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Application.FridgeModels.Queries.GetFridgeModel
{
    public class GetFridgeModelQuery : IRequest<FridgeModelVm>
    {
        public Guid Id { get; set; }
    }
}
