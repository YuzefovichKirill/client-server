using MediatR;
using Server.Application.Interfaces;
using Server.Application.Common.Exceptions;
using Server.Domain;

namespace Server.Application.FridgeProducts.Commands.DeleteFridgeProduct
{
    public class DeleteFridgeProductCommandHandler
    {
        private readonly IServerDbContext _dbContext;

        public DeleteFridgeProductCommandHandler(IServerDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<Unit> Handle(DeleteFridgeProductCommand request,
            CancellationToken cancellationToken)
        {
            var fridgeProduct = await _dbContext.FridgeProducts.FindAsync(new object[] { request.Id }, cancellationToken);

            if (fridgeProduct == null)
            {
                throw new NotFoundException(nameof(FridgeProduct), request.Id);
            }

            _dbContext.FridgeProducts.Remove(fridgeProduct);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
