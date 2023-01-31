using AutoMapper;
using Server.Application.Common.Exceptions;
using Server.Application.Products.Queries.GetProduct;
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
    public class GetProductQueryHandlerTests
    {
        private readonly ServerDbContext context;
        private readonly IMapper mapper;

        public GetProductQueryHandlerTests(QueryTestFixture fixture)
        {
            context = fixture.context;
            mapper = fixture.mapper;
        }

        [Fact]
        public async Task GetProductQueryHandler_Success()
        {
            var handler = new GetProductQueryHandler(context, mapper);

            var result = await handler.Handle(
                new GetProductQuery
                { 
                    Id = ContextFactory.productGuids[0]
                },
                CancellationToken.None);

            result.ShouldBeOfType<ProductVm>();
            result.Name.ShouldBe("Cucumber");
            result.DefaultQuantity.ShouldBe(2);
        }

        [Fact]
        public async Task GetProductQueryHandler_FailOnWrongId()
        {
            var handler = new GetProductQueryHandler(context, mapper);

            await Assert.ThrowsAsync<NotFoundException>(async () =>
                await handler.Handle(
                    new GetProductQuery
                    {
                        Id = Guid.NewGuid()
                    }, 
                    CancellationToken.None));
        }
    }
}
