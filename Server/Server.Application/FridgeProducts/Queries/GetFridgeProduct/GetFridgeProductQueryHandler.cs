using AutoMapper;
using MediatR;
using Server.Application.Common.Exceptions;
using Server.Application.Interfaces;
using Server.Domain;

namespace Server.Application.FridgeProducts.Queries.GetFridgeProduct
{
    public class GetFridgeProductQueryHandler
        : IRequestHandler<GetFridgeProductQuery, FridgeProductVm>
    {
        private readonly IServerDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetFridgeProductQueryHandler(IServerDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<FridgeProductVm> Handle(GetFridgeProductQuery request,
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

            var fridgeProduct = await _dbContext.FridgeProducts.FindAsync(new object[] {request.FridgeId, request.ProductId}, cancellationToken);

            if (fridgeProduct == null)
            {
                throw new NotFoundException(nameof(FridgeProduct), request.ProductId.ToString() + " " + request.FridgeId.ToString());
            }

            FridgeProductVm fridgeProductVm = _mapper.Map<FridgeProductVm>(fridgeProduct);
            fridgeProductVm.DefaultQuantity = product.DefaultQuantity;
            fridgeProductVm.FridgeName = fridge.Name;

            return fridgeProductVm;
        }
    }
}
