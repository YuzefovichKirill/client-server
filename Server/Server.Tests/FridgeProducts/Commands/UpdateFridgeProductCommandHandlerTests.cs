using Server.Application.Common.Exceptions;
using Server.Application.FridgeProducts.Commands.UpdateFridgeProduct;
using Server.Tests.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Tests.FridgeProducts.Commands
{
    public class UpdateFridgeProductCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task UpdateFridgeProductCommandHandler_Success()
        {
            var handler = new UpdateFridgeProductCommandHandler(context);
            var fridgeProductQuantinty = 135;

            await handler.Handle(new UpdateFridgeProductCommand
            {
                Id = ContextFactory.fridgeProductGuids[0],
                FridgeId = ContextFactory.fridgeGuids[1],
                ProductId = ContextFactory.productGuids[1],
                Quantity = fridgeProductQuantinty
            },
            CancellationToken.None);

            Assert.NotNull(context.FridgeProducts.SingleOrDefault(fridgeProduct =>
                fridgeProduct.Id == ContextFactory.fridgeProductGuids[0] &&
                fridgeProduct.FridgeId == ContextFactory.fridgeGuids[1] && 
                fridgeProduct.ProductId == ContextFactory.fridgeGuids[1]));
        }

        [Fact]
        public async Task UpdateFridgeProductCommandHandler_FailOnWrongId()
        {
            var handler = new UpdateFridgeProductCommandHandler(context);
            var fridgeProductQuantinty = 135;

            await Assert.ThrowsAsync<NotFoundException>(async () =>
               await handler.Handle(
                    new UpdateFridgeProductCommand
                    {
                        Id = Guid.NewGuid(),
                        FridgeId = ContextFactory.fridgeGuids[1],
                        ProductId = ContextFactory.productGuids[1],
                        Quantity = fridgeProductQuantinty
                    },
                    CancellationToken.None));     
        }


       [Fact]
        public async Task UpdateFridgeProductCommandHandler_FailOnWrongFridgeId()
        {
            var handler = new UpdateFridgeProductCommandHandler(context);
            var fridgeProductQuantinty = 135;

            await Assert.ThrowsAsync<NotFoundException>(async () =>
               await handler.Handle(
                    new UpdateFridgeProductCommand
                    {
                        Id = ContextFactory.fridgeProductGuids[0],
                        FridgeId = Guid.NewGuid(),
                        ProductId = ContextFactory.productGuids[1],
                        Quantity = fridgeProductQuantinty
                    },
                    CancellationToken.None));
        }

        [Fact]
        public async Task UpdateFridgeProductCommandHandler_FailOnWrongProductId()
        {
            var handler = new UpdateFridgeProductCommandHandler(context);
            var fridgeProductQuantinty = 135;

            await Assert.ThrowsAsync<NotFoundException>(async () =>
               await handler.Handle(
                    new UpdateFridgeProductCommand
                    {
                        Id = ContextFactory.fridgeProductGuids[0],
                        FridgeId = ContextFactory.fridgeGuids[1],
                        ProductId = Guid.NewGuid(),
                        Quantity = fridgeProductQuantinty
                    },
                    CancellationToken.None));
        }
    }
}
