using Microsoft.EntityFrameworkCore;
using Server.Application.Common.Exceptions;
using Server.Application.FridgeProducts.Commands.CreateFridgeProduct;
using Server.Tests.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Tests.FridgeProducts.Commands
{
    public class CreateFridgeProductCommandHandlerTests :TestCommandBase
    {
        [Fact]
        public async Task CreateFridgeProductCommandHandler_Success()
        {
            var handler = new CreateFridgeProductCommandHandler(context);
            var fridgeProductQuantinty = 135;

            var id = await handler.Handle(
                new CreateFridgeProductCommand
                {
                    FridgeId = ContextFactory.fridgeGuids[1],
                    ProductId = ContextFactory.productGuids[1],
                    Quantity = fridgeProductQuantinty
                },
                CancellationToken.None);

            Assert.NotNull(await context.FridgeProducts.FirstOrDefaultAsync(fridgeProduct =>
                fridgeProduct.Id == id &&
                fridgeProduct.FridgeId == ContextFactory.fridgeGuids[1] &&
                fridgeProduct.ProductId == ContextFactory.productGuids[1] &&
                fridgeProduct.Quantity == fridgeProductQuantinty));
        }

        [Fact]
        public async Task CreateFridgeProductCommandHandler_FailOnWrongFridgeId()
        {
            var handler = new CreateFridgeProductCommandHandler(context);
            var fridgeProductQuantinty = 135;

            await Assert.ThrowsAsync<NotFoundException>(async () =>
                await handler.Handle(
                    new CreateFridgeProductCommand
                    {
                        FridgeId = Guid.NewGuid(),
                        ProductId = ContextFactory.productGuids[1],
                        Quantity = fridgeProductQuantinty
                    },
                    CancellationToken.None));
        }

        [Fact]
        public async Task CreateFridgeProductCommandHandler_FailOnWrongProductId()
        {
            var handler = new CreateFridgeProductCommandHandler(context);
            var fridgeProductQuantinty = 135;

            await Assert.ThrowsAsync<NotFoundException>(async () =>
                await handler.Handle(
                    new CreateFridgeProductCommand
                    {
                        FridgeId = ContextFactory.fridgeGuids[1],
                        ProductId = Guid.NewGuid(),
                        Quantity = fridgeProductQuantinty
                    },
                    CancellationToken.None));
        }
    }
}
