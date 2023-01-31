using Server.Application.Common.Exceptions;
using Server.Application.Products.Commands.DeleteProduct;
using Server.Tests.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Tests.Products.Commands
{
    public class DeleteProductCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task DeleteProductCommandHandler_Success()
        {
            var handler = new DeleteProductCommandHandler(context);

            await handler.Handle(new DeleteProductCommand
            {
                Id = ContextFactory.productGuids[0]
            },
            CancellationToken.None);

            Assert.Null(context.Products.SingleOrDefault(product =>
                product.Id == ContextFactory.productGuids[0]));
        }

        public async Task DeleteProductCommandHandler_FailOnWrongId()
        {
            var handler = new DeleteProductCommandHandler(context);

            await Assert.ThrowsAsync<NotFoundException>(async () =>
                await handler.Handle(
                    new DeleteProductCommand
                    {
                        Id = Guid.NewGuid()
                    },
                    CancellationToken.None));
        }
    }
}
