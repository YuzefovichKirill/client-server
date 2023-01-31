using Microsoft.EntityFrameworkCore;
using Server.Application.FridgeModels.Commands.CreateFridgeModel;
using Server.Tests.Common;

namespace Server.Tests.FridgeModels.Commands
{
    public class CreateFridgeModelCommandHandlerTests :TestCommandBase
    {
        [Fact]
        public async Task CreateFridgeModelCommandHandler_Success()
        {
            var handler = new CreateFridgeModelCommandHandler(context);
            var fridgeName = "Fridge name";
            var fridgeYear = 2000;

            var id = await handler.Handle(
                new CreateFridgeModelCommand
                {
                    Name = fridgeName,
                    Year = fridgeYear,
                },
                CancellationToken.None);
                
            Assert.NotNull(await context.FridgeModels.FirstOrDefaultAsync(fridgeModel =>
                fridgeModel.Id == id && fridgeModel.Name == fridgeName &&
                fridgeModel.Year == fridgeYear));
        }
    }
}
