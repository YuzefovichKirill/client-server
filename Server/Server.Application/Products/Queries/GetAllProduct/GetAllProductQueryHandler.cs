using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Server.Application.Common.Exceptions;
using Server.Application.Interfaces;
using Server.Domain;

namespace Server.Application.Products.Queries.GetAllProduct
{
    public class GetAllProductQueryHandler
        : IRequestHandler<GetAllPRoductQuery, ProductListVm>
    {
        private readonly IServerDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetAllProductQueryHandler(IServerDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<ProductListVm> Handle(GetAllPRoductQuery request,
            CancellationToken cancellationToken)
        {
            var productsList = await _dbContext.Products.ToListAsync(cancellationToken);
            
            if (productsList == null)
            {
                throw new NotFoundException(nameof(Product), -1);
            }

            return new ProductListVm { products = new List<Product>(productsList) };
        }
    }
}
