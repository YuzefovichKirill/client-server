using MediatR;
using Server.Application.Interfaces;
using Server.Application.Common.Exceptions;
using Server.Domain;

namespace Server.Application.Fridges.Commands.DeleteFridge
{
    public class DeleteFridgeCommandHandler
        : IRequestHandler<DeleteFridgeCommand>
    {
        private readonly IServerDbContext _dbContext;

        public DeleteFridgeCommandHandler(IServerDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<Unit> Handle(DeleteFridgeCommand request,
            CancellationToken cancellationToken)
        {
            var fridge = await _dbContext.Fridges.FindAsync(new object[] { request.Id }, cancellationToken);

            if (fridge == null)
            {
                throw new NotFoundException(nameof(Fridge), request.Id);
            }

            _dbContext.Fridges.Remove(fridge);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
