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
            var fridgeModel = await _dbContext.FridgeModels.FindAsync(new object[] { request.Id }, cancellationToken);

            if (fridgeModel == null)
            {
                throw new NotFoundException(nameof(FridgeModel), request.Id);
            }

            fridgeModel.Id = request.Id;
            fridgeModel.Name = request.Name;
            fridgeModel.Year = request.Year;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
