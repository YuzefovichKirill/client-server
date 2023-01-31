using Server.Application.Common.Exceptions;
using Server.Application.FridgeModels.Commands.DeleteFridgeModel;
using Server.Tests.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Tests.FridgeModels.Commands
{
    public class DeleteFridgeModelCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task DeleteFridgeModelCommandHandler_Success()
        {
            var handler = new DeleteFridgeModelCommandHandler(context);

            await handler.Handle(new DeleteFridgeModelCommand
            {
                Id = ContextFactory.fridgeModelGuids[0]
            },
            CancellationToken.None);

            Assert.Null(context.FridgeModels.SingleOrDefault(fridgeModel =>
                fridgeModel.Id == ContextFactory.fridgeModelGuids[0]));
        }

        [Fact]
        public async Task DeleteFridgeModelCommandHandler_FailOnWrongId()
        {
            var handler = new DeleteFridgeModelCommandHandler(context);

            await Assert.ThrowsAsync<NotFoundException>(async () =>
                await handler.Handle(
                    new DeleteFridgeModelCommand
                    {
                        Id = Guid.NewGuid()
                    },
                    CancellationToken.None));
        }
    }
}
