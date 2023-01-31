using AutoMapper;
using Server.Application.FridgeModels.Queries.GetAllFridgeModel;
using Server.Application.FridgeModels.Queries.GetFridgeModel;
using Server.Persistence;
using Server.Tests.Common;
using Shouldly;

namespace Server.Tests.FridgeModels.Queries
{
    [Collection("QueryCollection")]
    public class GetAllFridgeModelQueryHandlerTests
    {
        private readonly ServerDbContext context;
        private readonly IMapper mapper;

        public GetAllFridgeModelQueryHandlerTests(QueryTestFixture fixture)
        {
            context = fixture.context;
            mapper = fixture.mapper;
        }

        [Fact]
        public async Task GetAllFridgeModelQueryHandler_Success()
        {
            var handler = new GetAllFridgeModelQueryHandler(context, mapper);

            var result = await handler.Handle(
                new GetAllFridgeModelQuery { },
                CancellationToken.None);

            result.ShouldBeOfType<FridgeModelListVm>();
            result.fridgeModels.Count.ShouldBe(2);
        }
    }
}
