using MediatR;
using Server.Application.Common.Exceptions;
using Server.Application.Interfaces;
using Server.Domain;

namespace Server.Application.Fridges.Commands.CreateFridge
{
    public class CreateFridgeCommandHandler : 
        IRequestHandler<CreateFridgeCommand, Guid>
    {
        private readonly IServerDbContext _dbContext;

        public CreateFridgeCommandHandler(IServerDbContext dbContext) =>
              _dbContext = dbContext;

        public async Task<Guid> Handle(CreateFridgeCommand request,
            CancellationToken cancellationToken)
        {
            var fridgeModel = await _dbContext.FridgeModels.FindAsync(new object[] { request.FridgeModelId }, cancellationToken);

            if (fridgeModel == null)
            {
                throw new NotFoundException(nameof(FridgeModel), request.FridgeModelId);
            }

            var fridge = new Fridge
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                OwnerName = request.OwnerName,
                FridgeModelId = request.FridgeModelId
            };

            await _dbContext.Fridges.AddAsync(fridge, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return fridge.Id;
        }
    }
}
