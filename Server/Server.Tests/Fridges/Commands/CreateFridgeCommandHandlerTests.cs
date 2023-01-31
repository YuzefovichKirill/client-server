using Microsoft.EntityFrameworkCore;
using Server.Application.Common.Exceptions;
using Server.Application.Fridges.Commands.CreateFridge;
using Server.Tests.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Tests.Fridges.Commands
{
    public class CreateFridgeCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task CreateFridgeCommandHandler_Success()
        {
            var handler = new CreateFridgeCommandHandler(context);
            var fridgeName = "Bosch";
            var fridgeOwnerName = "Alice";

            var id = await handler.Handle(
                new CreateFridgeCommand
                {
                    Name = fridgeName,
                    OwnerName = fridgeOwnerName,
                    FridgeModelId = ContextFactory.fridgeModelGuids[0]
                },
                CancellationToken.None);

            Assert.NotNull(await context.Fridges.FirstOrDefaultAsync(fridge =>
                fridge.Id == id && fridge.Name == fridgeName &&
                fridge.OwnerName == fridgeOwnerName &&
                fridge.FridgeModelId == ContextFactory.fridgeModelGuids[0]));
        }

        public async Task CreateFridgeCommandHandler_FailOnWrongFridgeModelId()
        {
            var handler = new CreateFridgeCommandHandler(context);
            var fridgeName = "Bosch";
            var fridgeOwnerName = "Alice";

            await Assert.ThrowsAsync<NotFoundException>(async () => 
                await handler.Handle(
                    new CreateFridgeCommand
                    {
                        Name = fridgeName,
                        OwnerName = fridgeOwnerName,
                        FridgeModelId = Guid.NewGuid()
                    },
                    CancellationToken.None));
        }
    }
}
