using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Server.Application.Interfaces;
using Server.Application.Common.Exceptions;
using Server.Domain;

namespace Server.Application.Fridges.Queries.GetAllFridge
{
    public class GetAllFridgeQueryHandler
        : IRequestHandler<GetAllFridgeQuery, FridgeListVm>
    {
        private readonly IServerDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetAllFridgeQueryHandler(IServerDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<FridgeListVm> Handle(GetAllFridgeQuery request,
            CancellationToken cancellationToken)
        {
            var fridgesList = await _dbContext.Fridges.ToListAsync(cancellationToken);

            if (fridgesList == null)
            {
                throw new NotFoundException(nameof(Fridge), -1);
            }

            return new FridgeListVm { fridges = new List<Fridge>(fridgesList) };
        }
    }
}
