using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Application.FridgeProducts.Queries.GetFridgeProduct
{
    public class GetFridgeProductQuery : IRequest<FridgeProductVm>
    {
        public Guid FridgeId { get; set; }
        public Guid ProductId { get; set; }
    }
}
