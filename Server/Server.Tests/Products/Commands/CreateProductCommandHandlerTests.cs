using Microsoft.EntityFrameworkCore;
using Server.Application.Products.Commands.CreateProduct;
using Server.Tests.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Tests.Products.Commands
{
    public class CreateProductCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task CreateProductCommandHandler_Success()
        {
            var handler = new CreateProductCommandHandler(context);
            var productName = "Product name";
            var productDefaultQuantity = 1000;

            var id = await handler.Handle(
                new CreateProductCommand
                {
                    Name = productName,
                    DefaultQuantity = productDefaultQuantity,
                },
                CancellationToken.None);

            Assert.NotNull(await context.Products.FirstOrDefaultAsync(product =>
                product.Id == id && product.Name == productName &&
                product.DefaultQuantity == productDefaultQuantity));
        }
    }
}
