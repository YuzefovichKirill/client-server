using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Server.Application.Interfaces;
using Server.Application.Common.Exceptions;
using Server.Domain;

namespace Server.Application.FridgeModels.Queries.GetFridgeModel
{
    public class GetFridgeModelQueryHandler
        : IRequestHandler<GetFridgeModelQuery, FridgeModelVm>
    {
        private readonly IServerDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetFridgeModelQueryHandler(IServerDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
                _mapper = mapper;
            }
    
        public async Task<FridgeModelVm> Handle(GetFridgeModelQuery request,
            CancellationToken cancellationToken)
        {
            var entity = await _dbContext.FridgeModels
                .FirstOrDefaultAsync(fridgeModel => fridgeModel.Id == request.Id, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(FridgeModel), request.Id);
            }

            return _mapper.Map<FridgeModelVm>(entity);
        }
    }
}
