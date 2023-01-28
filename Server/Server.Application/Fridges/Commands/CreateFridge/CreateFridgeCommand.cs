using MediatR;

namespace Server.Application.Fridges.Commands.CreateFridge
{
    public class CreateFridgeCommand : IRequest<Guid>
    {
        public string Name { get; set; }
        public string OwnerName { get; set; }
        public Guid FridgeModelId { get; set; }
    }
}
