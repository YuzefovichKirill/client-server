using MediatR;

namespace Server.Application.FridgeProducts.Commands.CreateFridgeProduct
{
    public class CreateFridgeProductCommand : IRequest<Guid>
    {
        public Guid ProductId { get; set; }
        public Guid FridgeId { get; set; }
        public int Quantity { get; set; }
    }
}
