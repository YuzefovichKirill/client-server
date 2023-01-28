using MediatR;
using Microsoft.EntityFrameworkCore;
using Server.Application.Common.Exceptions;
using Server.Application.Interfaces;
using Server.Domain;

namespace Server.Application.Products.Commands.UpdateProduct
{
    public class UpdateProductCommandHandler
        : IRequestHandler<UpdateProductCommand>
    {
        private readonly IServerDbContext _dbContext;

        public UpdateProductCommandHandler(IServerDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<Unit> Handle(UpdateProductCommand request,
            CancellationToken cancellationToken)
        {
            var product = await _dbContext.Products.FindAsync(new object[] { request.Id }, cancellationToken);

            if (product == null)
            {
                throw new NotFoundException(nameof(Product), request.Id);
            }

            product.Id = request.Id;
            product.Name = request.Name;
            product.DefaultQuantity = request.DefaultQuantity;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
