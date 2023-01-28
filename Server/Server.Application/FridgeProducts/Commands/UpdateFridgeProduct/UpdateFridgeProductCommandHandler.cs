using MediatR;
using Server.Application.Common.Exceptions;
using Server.Application.Interfaces;
using Server.Domain;

namespace Server.Application.FridgeProducts.Commands.UpdateFridgeProduct
{
    public class UpdateFridgeProductCommandHandler
        : IRequestHandler<UpdateFridgeProductCommand>
    {
        private readonly IServerDbContext _dbContext;

        public UpdateFridgeProductCommandHandler(IServerDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<Unit> Handle(UpdateFridgeProductCommand request,
            CancellationToken cancellationToken)
        {
            var fridge = await _dbContext.Fridges.FindAsync(new object[] { request.FridgeId }, cancellationToken);

            if (fridge == null)
            {
                throw new NotFoundException(nameof(Fridge), request.FridgeId);
            }

            var product = await _dbContext.Products.FindAsync(new object[] { request.ProductId }, cancellationToken);

            if (product == null)
            {
                throw new NotFoundException(nameof(Product), request.ProductId);
            }

            var fridgeProduct = await _dbContext.FridgeProducts.FindAsync(new object[] { request.Id }, cancellationToken);
        
            if (fridgeProduct == null)
            {
                throw new NotFoundException(nameof(FridgeProduct), request.Id);
            }

            fridgeProduct.Id = request.Id;
            fridgeProduct.FridgeId = request.FridgeId;
            fridgeProduct.ProductId = request.ProductId;
            fridgeProduct.Quantity = request.Quantity;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
