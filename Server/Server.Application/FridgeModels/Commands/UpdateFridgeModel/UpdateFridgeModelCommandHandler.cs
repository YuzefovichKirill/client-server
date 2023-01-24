using MediatR;
using Microsoft.EntityFrameworkCore;
using Server.Application.Interfaces;
using Server.Application.Common.Exceptions;
using Server.Domain;
using System.Windows.Input;

namespace Server.Application.FridgeModels.Commands.UpdateFridgeModel
{
    public class UpdateFridgeModelCommandHandler
        : IRequestHandler<UpdateFridgeModelCommand>
    {
        private readonly IServerDbContext _dbContext;

        public UpdateFridgeModelCommandHandler(IServerDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<Unit> Handle(UpdateFridgeModelCommand request,
            CancellationToken cancellationToken)
        {
            var entity = await _dbContext.FridgeModels.FirstOrDefaultAsync(fridgeModel =>
                fridgeModel.Id == request.Id, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(FridgeModel), request.Id);
            }

            entity.Id = request.Id;
            entity.Name = request.Name;
            entity.Year = request.Year;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
