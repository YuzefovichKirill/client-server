using MediatR;

namespace Server.Application.Products.Queries.GetProduct
{
    public class GetProductQuery : IRequest<ProductVm>
    {
        public Guid Id { get; set; }
    }
}
