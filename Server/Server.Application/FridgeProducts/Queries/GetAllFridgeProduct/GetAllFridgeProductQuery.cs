using MediatR;

namespace Server.Application.FridgeProducts.Queries.GetAllFridgeProduct
{
    public class GetAllFridgeProductQuery : IRequest<FridgeProductListVm>
    {
        public Guid FridgeId { get; set; }
    }
}
