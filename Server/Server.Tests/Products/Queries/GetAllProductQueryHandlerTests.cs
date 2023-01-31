using AutoMapper;
using Server.Application.Products.Queries.GetAllProduct;
using Server.Persistence;
using Server.Tests.Common;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Tests.Products.Queries
{
    [Collection("QueryCollection")]
    public class GetAllProductQueryHandlerTests
    {
        private readonly ServerDbContext context;
        private readonly IMapper mapper;

        public GetAllProductQueryHandlerTests(QueryTestFixture fixture)
        {
            context = fixture.context;
            mapper = fixture.mapper;
        }

        [Fact]
        public async Task GetAllProductQueryHandler_Success()
        {
            var handler = new GetAllProductQueryHandler(context, mapper);

            var result = await handler.Handle(
                new GetAllPRoductQuery { },
                CancellationToken.None);

            result.ShouldBeOfType<ProductListVm>();
            result.products.Count.ShouldBe(2);
        }
    }
}
