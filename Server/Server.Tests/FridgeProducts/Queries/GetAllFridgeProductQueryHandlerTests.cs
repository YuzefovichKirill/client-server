using AutoMapper;
using Server.Application.Common.Exceptions;
using Server.Application.FridgeProducts.Queries.GetAllFridgeProduct;
using Server.Persistence;
using Server.Tests.Common;
using Shouldly;

namespace Server.Tests.FridgeProducts.Queries
{
    [Collection("QueryCollection")]
    public class GetAllFridgeProductQueryHandlerTests
    {
        private readonly ServerDbContext context;
        private readonly IMapper mapper;

        public GetAllFridgeProductQueryHandlerTests(QueryTestFixture fixture)
        {
            context = fixture.context;
            mapper = fixture.mapper;
        }

        [Fact]
        public async Task GetAllFridgeProductQueryHandler_Success()
        {
            var handler = new GetAllFridgeProductQueryHandler(context, mapper);

            var result = await handler.Handle(
                new GetAllFridgeProductQuery 
                { 
                    FridgeId = ContextFactory.fridgeGuids[0]
                },
                CancellationToken.None);

            result.ShouldBeOfType<FridgeProductListVm>();
            result.fridgeProducts.Count.ShouldBe(2);
        }

        [Fact]
        public async Task GetAllFridgeProductQueryHandler_FailOnWrongFridgeId()
        {
            var handler = new GetAllFridgeProductQueryHandler(context, mapper);

            await Assert.ThrowsAsync<NotFoundException>(async () =>
                await handler.Handle(
                     new GetAllFridgeProductQuery
                     {
                         FridgeId = Guid.NewGuid()
                     },
                     CancellationToken.None));

        }
    }
}
