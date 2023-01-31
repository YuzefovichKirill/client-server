using Server.Application.Common.Exceptions;
using Server.Application.FridgeModels.Commands.UpdateFridgeModel;
using Server.Tests.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Tests.FridgeModels.Commands
{
    public class UpdateFridgeModelCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task UpdateFridgeModelCommandHandler_Success()
        {
            var handler = new UpdateFridgeModelCommandHandler(context);
            var fridgeName = "New name";
            var fridgeYear = 2001;

            await handler.Handle(new UpdateFridgeModelCommand
            {
                Id = ContextFactory.fridgeModelGuids[0],
                Name = fridgeName,
                Year = fridgeYear
            },
            CancellationToken.None);

            Assert.NotNull(context.FridgeModels.SingleOrDefault(fridgeModel =>
                fridgeModel.Id == ContextFactory.fridgeModelGuids[0]));
        }

        [Fact]
        public async Task UpdateFridgeModelCommandHandler_FailOnWrongId()
        {
            var handler = new UpdateFridgeModelCommandHandler(context);
            var fridgeName = "New name";
            var fridgeYear = 2001;

            await Assert.ThrowsAsync<NotFoundException>(async () =>
                await handler.Handle(
                    new UpdateFridgeModelCommand
                    {
                        Id = Guid.NewGuid(),
                        Name = fridgeName,
                        Year = fridgeYear
                    },
                    CancellationToken.None));
        }
    }
}
