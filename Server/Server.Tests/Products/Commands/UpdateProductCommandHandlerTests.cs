using Server.Application.Common.Exceptions;
using Server.Application.Products.Commands.UpdateProduct;
using Server.Tests.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Tests.Products.Commands
{
    public class UpdateProductCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task UpdateProductCommandHandler_Success()
        {
            var handler = new UpdateProductCommandHandler(context);
            var productName = "New name";
            var productDefaultQuantity = 2001;

            await handler.Handle(new UpdateProductCommand
            {
                Id = ContextFactory.productGuids[0],
                Name = productName,
                DefaultQuantity = productDefaultQuantity
            },
            CancellationToken.None);
        
            Assert.NotNull(context.Products.SingleOrDefault(product =>
                product.Id == ContextFactory.productGuids[0]));
        }

        [Fact]
        public async Task UpdateProductCommandHandler_FailOnWrongId()
        {
            var handler = new UpdateProductCommandHandler(context);
            var productName = "New name";
            var productDefaultQuantity = 2001;

            await Assert.ThrowsAsync<NotFoundException>(async () =>
                await handler.Handle(
                    new UpdateProductCommand
                    {
                        Id = Guid.NewGuid(),
                        Name = productName,
                        DefaultQuantity = productDefaultQuantity
                    },
                    CancellationToken.None));
        }
    }
}
