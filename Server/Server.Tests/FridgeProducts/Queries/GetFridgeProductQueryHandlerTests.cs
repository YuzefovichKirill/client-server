using AutoMapper;
using Server.Application.Common.Exceptions;
using Server.Application.FridgeProducts.Queries.GetAllFridgeProduct;
using Server.Application.FridgeProducts.Queries.GetFridgeProduct;
using Server.Persistence;
using Server.Tests.Common;
using Shouldly;

namespace Server.Tests.FridgeProducts.Queries
{
    [Collection("QueryCollection")]
    public class GetFridgeProductQueryHandlerTests
    {
        private readonly ServerDbContext context;
        private readonly IMapper mapper;

        public GetFridgeProductQueryHandlerTests(QueryTestFixture fixture)
        {
            context = fixture.context;
            mapper = fixture.mapper;
        }

        [Fact]
        public async Task GetFridgeProductQueryHandler_Success()
        {
            var handler = new GetFridgeProductQueryHandler(context, mapper);

            var result = await handler.Handle(
                new GetFridgeProductQuery
                {
                    FridgeId = ContextFactory.fridgeGuids[0],
                    ProductId = ContextFactory.productGuids[0]
                },
                CancellationToken.None);

            result.ShouldBeOfType<FridgeProductVm>();
            result.ProductId.ShouldBe(ContextFactory.productGuids[0]);
            result.FridgeId.ShouldBe(ContextFactory.fridgeGuids[0]);
            result.Quantity.ShouldBe(5);
        }

        [Fact]
        public async Task GetFridgeProductQueryHandler_FailOnWrongFridgeId()
        {
            var handler = new GetFridgeProductQueryHandler(context, mapper);

            await Assert.ThrowsAsync<NotFoundException>(async () =>
                await handler.Handle(
                    new GetFridgeProductQuery
                    {
                        FridgeId = Guid.NewGuid(),
                        ProductId = ContextFactory.productGuids[0]
                    },
                    CancellationToken.None));
        }

        [Fact]
        public async Task GetFridgeProductQueryHandler_FailOnWrongProductId()
        {
            var handler = new GetFridgeProductQueryHandler(context, mapper);

            await Assert.ThrowsAsync<NotFoundException>(async () =>
                await handler.Handle(
                    new GetFridgeProductQuery
                    {
                        FridgeId = ContextFactory.fridgeGuids[0],
                        ProductId = Guid.NewGuid()
                    },
                    CancellationToken.None));
        }
    }
}
