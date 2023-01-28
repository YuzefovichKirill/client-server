using MediatR;

namespace Server.Application.Fridges.Queries.GetFridge
{
    public class GetFridgeQuery : IRequest<FridgeVm>
    {
        public Guid Id { get; set; }
    }
}
