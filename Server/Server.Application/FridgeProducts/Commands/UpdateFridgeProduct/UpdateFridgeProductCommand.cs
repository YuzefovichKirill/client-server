using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Application.FridgeProducts.Commands.UpdateFridgeProduct
{
    public class UpdateFridgeProductCommand : IRequest
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public Guid FridgeId { get; set; }
        public int Quantity { get; set; }
    }
}
