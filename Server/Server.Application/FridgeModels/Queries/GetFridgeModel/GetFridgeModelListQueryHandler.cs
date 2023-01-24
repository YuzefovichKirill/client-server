using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Server.Application.Interfaces;

namespace Server.Application.FridgeModels.Queries.GetFridgeModel
{
    public class GetFridgeModelListQueryHandler
        : IRequestHandler<GetFridgeModelListQuery, FridgeModelListVm>
    {
        private readonly IServerDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetFridgeModelListQueryHandler(IServerDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
    
        public async Task<FridgeModelListVm> Handle(GetFridgeModelListQuery request,
            CancellationToken cancellationToken)
        {
            var FridgeModelQuery = await _dbContext.FridgeModels
                .Where(fridgeModel => fridgeModel.Id == request.Id)
                .ProjectTo<FridgeModelDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new FridgeModelListVm { FridgeModels = FridgeModelQuery };
        }
    }
}
