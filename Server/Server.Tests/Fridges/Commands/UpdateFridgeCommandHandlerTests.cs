using Server.Application.Common.Exceptions;
using Server.Application.Fridges.Commands.UpdateFridge;
using Server.Tests.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Tests.Fridges.Commands
{
    public class UpdateFridgeCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task UpdateFridgeCommandHandler_Success()
        {
            var handler = new UpdateFridgeCommandHandler(context);
            var fridgeName = "Bosch";
            var fridgeOwnerName = "Alice";

            await handler.Handle(new UpdateFridgeCommand
            {
                Id = ContextFactory.fridgeGuids[0],
                Name = fridgeName,
                OwnerName = fridgeOwnerName,
                FridgeModelId = ContextFactory.fridgeModelGuids[0],
            },
            CancellationToken.None);

            Assert.NotNull(context.Fridges.SingleOrDefault(fridge =>
                fridge.Id == ContextFactory.fridgeGuids[0] &&
                fridge.FridgeModelId == ContextFactory.fridgeModelGuids[0]));
        }

        [Fact]
        public async Task UpdateFridgeCommandHandler_FailOnWrongId()
        {
            var handler = new UpdateFridgeCommandHandler(context);
            var fridgeName = "Bosch";
            var fridgeOwnerName = "Alice";

            await Assert.ThrowsAsync<NotFoundException>(async () =>
                await handler.Handle(
                    new UpdateFridgeCommand
                    {
                        Id = Guid.NewGuid(),
                        Name = fridgeName,
                        OwnerName = fridgeOwnerName,
                        FridgeModelId = ContextFactory.fridgeModelGuids[0]
                    },
                    CancellationToken.None));
        }


        [Fact]
        public async Task UpdateFridgeCommandHandler_FailOnWrongFridgeModelId()
        {
            var handler = new UpdateFridgeCommandHandler(context);
            var fridgeName = "Bosch";
            var fridgeOwnerName = "Alice";

            await Assert.ThrowsAsync<NotFoundException>(async () =>
                await handler.Handle(
                    new UpdateFridgeCommand
                    {
                        Id = ContextFactory.fridgeGuids[0],
                        Name = fridgeName,
                        OwnerName = fridgeOwnerName,
                        FridgeModelId = Guid.NewGuid()
                    },
                    CancellationToken.None));
        }
    }
}
