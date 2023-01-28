using MediatR;
using Server.Application.Common.Exceptions;
using Server.Application.Interfaces;
using Server.Domain;

namespace Server.Application.FridgeProducts.Commands.CreateFridgeProduct
{
    public class CreateFridgeProductCommandHandler
        : IRequestHandler<CreateFridgeProductCommand, Guid>
    {
        private readonly IServerDbContext _dbContext;

        public CreateFridgeProductCommandHandler(IServerDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<Guid> Handle(CreateFridgeProductCommand request,
                CancellationToken cancellationToken)
        {
            var product = await _dbContext.Products.FindAsync(new object[] { request.ProductId }, cancellationToken);

            if (product == null)
            {
                throw new NotFoundException(nameof(Product), request.ProductId);
            }

            var fridge = await _dbContext.Fridges.FindAsync(new object[] { request.FridgeId }, cancellationToken);

            if (fridge == null)
            {
                throw new NotFoundException(nameof(Fridge), request.FridgeId);
            }

            var fridgeProduct = new FridgeProduct
            {
                Id = Guid.NewGuid(),
                ProductId = request.ProductId,
                FridgeId = request.FridgeId,
                Quantity = request.Quantity
            };

            await _dbContext.FridgeProducts.AddAsync(fridgeProduct, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return fridgeProduct.Id;
        }
    }
}
