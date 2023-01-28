using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Server.Application.Common.Exceptions;
using Server.Application.Interfaces;
using Server.Domain;

namespace Server.Application.FridgeProducts.Queries.GetAllFridgeProduct
{
    public class GetAllFridgeProductQueryHandler
        : IRequestHandler<GetAllFridgeProductQuery, FridgeProductListVm>
    {
        private readonly IServerDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetAllFridgeProductQueryHandler(IServerDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<FridgeProductListVm> Handle(GetAllFridgeProductQuery request,
            CancellationToken cancellationToken)
        {
            var fridge = await _dbContext.Fridges.FindAsync(new object[] { request.FridgeId }, cancellationToken);

            if (fridge == null)
            {
                throw new NotFoundException(nameof(Fridge), request.FridgeId);
            }

            var fridgeProductsList = await _dbContext.FridgeProducts
                .Where(fridgeProduct => fridgeProduct.FridgeId == request.FridgeId)
                .ProjectTo<FridgeProductDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            if (fridgeProductsList == null)
            {
                throw new NotFoundException(nameof(FridgeProduct), request.FridgeId);
            }

            return new FridgeProductListVm
            {
                fridge = fridge,
                fridgeProducts = fridgeProductsList
            };
        }
    }
}
