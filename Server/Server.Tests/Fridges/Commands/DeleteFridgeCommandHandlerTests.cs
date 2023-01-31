using Server.Application.Common.Exceptions;
using Server.Application.Fridges.Commands.DeleteFridge;
using Server.Tests.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Tests.Fridges.Commands
{
    public class DeleteFridgeCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task DeleteFridgeCommandHandler_Success()
        {
            var handler = new DeleteFridgeCommandHandler(context);

            await handler.Handle(new DeleteFridgeCommand
            {
                Id = ContextFactory.fridgeGuids[0]
            },
            CancellationToken.None);

            Assert.Null(context.Fridges.SingleOrDefault(fridge =>
                fridge.Id == ContextFactory.fridgeGuids[0]));
        }

        [Fact]
        public async Task DeleteFridgeCommandHandler_FailOnWrongId()
        {
            var handler = new DeleteFridgeCommandHandler(context);

            await Assert.ThrowsAsync<NotFoundException>(async () =>
                await handler.Handle(
                    new DeleteFridgeCommand
                    { 
                        Id = Guid.NewGuid()
                    },
                    CancellationToken.None));
        }
    }
}
