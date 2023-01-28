using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Server.Application.Interfaces;
using Server.Domain;
using Server.Application.Common.Exceptions;

namespace Server.Application.Fridges.Queries.GetFridge
{
    public class GetFridgeQueryHandler
        : IRequestHandler<GetFridgeQuery, FridgeVm>
    {
        private readonly IServerDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetFridgeQueryHandler(IServerDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
 
        public async Task<FridgeVm> Handle(GetFridgeQuery request,
            CancellationToken cancellationToken)
        {
            var fridge = await _dbContext.Fridges.FindAsync(new object[] { request.Id }, cancellationToken);

            if (fridge == null)
            {
                throw new NotFoundException(nameof(Fridge), request.Id);
            }

            return _mapper.Map<FridgeVm>(fridge);
        }
    }
}
