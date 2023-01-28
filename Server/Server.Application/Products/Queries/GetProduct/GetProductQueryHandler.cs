using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Server.Application.Common.Exceptions;
using Server.Application.Interfaces;
using Server.Domain;

namespace Server.Application.Products.Queries.GetProduct
{
    public class GetProductQueryHandler
        : IRequestHandler<GetProductQuery, ProductVm>
    {
        private readonly IServerDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetProductQueryHandler(IServerDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<ProductVm> Handle(GetProductQuery request,
            CancellationToken cancellationToken)
        {
            var product = await _dbContext.Products.FindAsync(new object[] { request.Id }, cancellationToken);

            if (product == null)
            {
                throw new NotFoundException(nameof(Product), request.Id);
            }

            return _mapper.Map<ProductVm>(product);
        }
    }
}
