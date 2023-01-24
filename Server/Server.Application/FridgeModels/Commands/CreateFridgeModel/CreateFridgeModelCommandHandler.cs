using MediatR;
using Server.Application.Interfaces;
using Server.Domain;

namespace Server.Application.FridgeModels.Commands.CreateFridgeModel
{
    public class CreateFridgeModelCommandHandler : IRequestHandler<CreateFridgeModelCommand, Guid>
    {
        private readonly IServerDbContext _dbContext;

        public CreateFridgeModelCommandHandler(IServerDbContext dbContext) => 
            _dbContext = dbContext;
        

        public async Task<Guid> Handle(CreateFridgeModelCommand request,
            CancellationToken cancellationToken)
        {
            var fridgeModel = new FridgeModel
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Year = request.Year
            };

            await _dbContext.FridgeModels.AddAsync(fridgeModel, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return fridgeModel.Id;
        }
    }
}
