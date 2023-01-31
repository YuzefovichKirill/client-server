using Server.Application.Common.Exceptions;
using Server.Application.FridgeProducts.Commands.DeleteFridgeProduct;
using Server.Tests.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Tests.FridgeProducts.Commands
{
    public class DeleteFridgeProductCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task DeleteFridgeProductCommandHandler_Success()
        {
            var handler = new DeleteFridgeProductCommandHandler(context);

            await handler.Handle(new DeleteFridgeProductCommand
            {
                Id = ContextFactory.fridgeProductGuids[0]
            },
            CancellationToken.None);

            Assert.Null(context.FridgeProducts.SingleOrDefault(fridgeProduct =>
                fridgeProduct.Id == ContextFactory.fridgeProductGuids[0]));
        }

        [Fact]
        public async Task DeleteFridgeProductCommandHandler_FailOnWrongId()
        {
            var handler = new DeleteFridgeProductCommandHandler(context);

            await Assert.ThrowsAsync<NotFoundException>(async () =>
                await handler.Handle(
                    new DeleteFridgeProductCommand
                    {
                        Id = Guid.NewGuid()
                    },
                    CancellationToken.None));
        }
    }
}
