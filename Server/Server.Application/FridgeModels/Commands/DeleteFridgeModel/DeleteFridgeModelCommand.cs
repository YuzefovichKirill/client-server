using MediatR;

namespace Server.Application.FridgeModels.Commands.DeleteFridgeModel
{
    public class DeleteFridgeModelCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
