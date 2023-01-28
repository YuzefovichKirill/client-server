using MediatR;
using Microsoft.EntityFrameworkCore;
using Server.Application.Common.Exceptions;
using Server.Application.Interfaces;
using Server.Domain;

namespace Server.Application.Fridges.Commands.UpdateFridge
{
    public class UpdateFridgeCommandHandler
        : IRequestHandler<UpdateFridgeCommand>
    {
        private readonly IServerDbContext _dbContext;

        public UpdateFridgeCommandHandler(IServerDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<Unit> Handle(UpdateFridgeCommand request,
            CancellationToken cancellationToken)
        {
            var fridge = await _dbContext.Fridges.FindAsync(new object[] { request.Id }, cancellationToken);

            if (fridge == null)
            {
                throw new NotFoundException(nameof(Fridge), request.Id);
            }

            var fridgeModel = await _dbContext.FridgeModels.FindAsync(new object[] { request.FridgeModelId }, cancellationToken);

            if (fridgeModel == null)
            {
                throw new NotFoundException(nameof(FridgeModel), request.FridgeModelId);
            }

            fridge.Id = request.Id;
            fridge.Name = request.Name;
            fridge.OwnerName = request.OwnerName;
            fridge.FridgeModelId = request.FridgeModelId;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
