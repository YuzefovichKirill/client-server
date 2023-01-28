using MediatR;


namespace Server.Application.Fridges.Commands.DeleteFridge
{
    public class DeleteFridgeCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
