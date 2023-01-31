using AutoMapper;
using Server.Application.Common.Exceptions;
using Server.Application.FridgeModels.Queries.GetFridgeModel;
using Server.Persistence;
using Server.Tests.Common;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Tests.FridgeModels.Queries
{
    [Collection("QueryCollection")]
    public class GetFridgeModelQueryHandlerTests
    {
        private readonly ServerDbContext context;
        private readonly IMapper mapper;

        public GetFridgeModelQueryHandlerTests(QueryTestFixture fixture)
        {
            context = fixture.context;
            mapper = fixture.mapper;
        }

        [Fact]
        public async Task GetFridgeModelQueryHandler_Success()
        {
            var handler = new GetFridgeModelQueryHandler(context, mapper);

            var result = await handler.Handle(
                new GetFridgeModelQuery
                {
                    Id = ContextFactory.fridgeModelGuids[0]
                },
                CancellationToken.None);

            result.ShouldBeOfType<FridgeModelVm>();
            result.Name.ShouldBe("Bosch");
            result.Year.ShouldBe(2018);
        }

        [Fact]
        public async Task GetFridgeModelQueryHandler_FailOnWrongId()
        {
            var handler = new GetFridgeModelQueryHandler(context, mapper);

            await Assert.ThrowsAsync<NotFoundException>(async () =>
                await handler.Handle(
                    new GetFridgeModelQuery
                    {
                        Id = Guid.NewGuid()
                    },
                    CancellationToken.None));
        }
    }
}
