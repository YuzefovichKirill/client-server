using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Application.FridgeModels.Queries.GetFridgeModel
{
    public class GetFridgeModelListQuery : IRequest<FridgeModelListVm>
    {
        public Guid Id { get; set; }
    }
}
