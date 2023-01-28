using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Server.Application.Common.Exceptions;
using Server.Application.FridgeModels.Queries.GetFridgeModel;
using Server.Application.Interfaces;
using Server.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Application.FridgeModels.Queries.GetAllFridgeModel
{
    public class GetAllFridgeModelQueryHandler
     : IRequestHandler<GetAllFridgeModelQuery, FridgeModelListVm>
    {
        private readonly IServerDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetAllFridgeModelQueryHandler(IServerDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<FridgeModelListVm> Handle(GetAllFridgeModelQuery request,
            CancellationToken cancellationToken)
        {
            var fridgeModelsList = await _dbContext.FridgeModels.ToListAsync(cancellationToken);

            if (fridgeModelsList == null)
            {
                throw new NotFoundException(nameof(FridgeModel), -1);
            }

            return new FridgeModelListVm { fridgeModels = new List<FridgeModel>(fridgeModelsList) };
        }
    }
}
