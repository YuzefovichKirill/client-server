using MediatR;

namespace Server.Application.Fridges.Queries.GetAllFridge
{
    public class GetAllFridgeQuery : IRequest<FridgeListVm>
    {
    }
}
