using AutoMapper;
using Server.Application.Common.Exceptions;
using Server.Application.Fridges.Queries.GetFridge;
using Server.Persistence;
using Server.Tests.Common;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Tests.Fridges.Queries
{
    [Collection("QueryCollection")]
    public class GetFridgeQueryHandlerTests
    {
        private readonly ServerDbContext context;
        private readonly IMapper mapper;

        public GetFridgeQueryHandlerTests(QueryTestFixture fixture)
        {
            context = fixture.context;
            mapper = fixture.mapper;
        }

        [Fact]
        public async Task GetFridgeQueryHandler_Success()
        {
            var handler = new GetFridgeQueryHandler(context, mapper);

            var result = await handler.Handle(
                new GetFridgeQuery
                {
                    Id = ContextFactory.fridgeGuids[0]
                },
                CancellationToken.None);

            result.ShouldBeOfType<FridgeVm>();
            result.Name.ShouldBe("Top Freezer Refrigerator");
            result.OwnerName.ShouldBe("Kirill");
            result.FridgeModelId.ShouldBe(ContextFactory.fridgeModelGuids[0]);
        }


        [Fact]
        public async Task GetFridgeQueryHandler_FailOnWrongId()
        {
            var handler = new GetFridgeQueryHandler(context, mapper);

            await Assert.ThrowsAsync<NotFoundException>(async () =>
                await handler.Handle(
                    new GetFridgeQuery
                    {
                        Id = Guid.NewGuid()
                    },
                    CancellationToken.None));
        }
    }
}
