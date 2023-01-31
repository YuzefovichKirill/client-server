using AutoMapper;
using Server.Application.Fridges.Queries.GetAllFridge;
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
    public class GetAllFridgeQueryHandlerTests
    {
        private readonly ServerDbContext context;
        private readonly IMapper mapper;

        public GetAllFridgeQueryHandlerTests(QueryTestFixture fixture)
        {
            context = fixture.context;
            mapper = fixture.mapper;
        }

        [Fact]
        public async Task GetAllFridgeQueryHandler_Success()
        {
            var handler = new GetAllFridgeQueryHandler(context, mapper);

            var result = await handler.Handle(
                new GetAllFridgeQuery { },
                CancellationToken.None);

            result.ShouldBeOfType<FridgeListVm>();
            result.fridges.Count.ShouldBe(2);
        }
    }
}
