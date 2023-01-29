using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Server.Application.FridgeProducts.Commands.CreateFridgeProduct;
using Server.Application.FridgeProducts.Commands.DeleteFridgeProduct;
using Server.Application.FridgeProducts.Commands.UpdateFridgeProduct;
using Server.Application.FridgeProducts.Queries.GetAllFridgeProduct;
using Server.Application.FridgeProducts.Queries.GetFridgeProduct;

namespace Server.WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class FridgeProductController : BaseController
    {
        private readonly IMapper _mapper;

        public FridgeProductController(IMapper mapper) => _mapper = mapper;

        [HttpGet("{fridgeId}")]
        public async Task<ActionResult<FridgeProductListVm>> GetAll(Guid fridgeId)
        {
            var query = new GetAllFridgeProductQuery() {  FridgeId = fridgeId };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet("{fridgeId}{productId}")]
        public async Task<ActionResult<FridgeProductVm>> Get(Guid fridgeId, Guid productId)
        {
            var query = new GetFridgeProductQuery() { FridgeId = fridgeId, ProductId = productId };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateFridgeProductCommand createFridgeProductCommand)
        {
            var Id = await Mediator.Send(createFridgeProductCommand);
            return Ok(Id);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateFridgeProductCommand updateFridgeProductCommand)
        {
            await Mediator.Send(updateFridgeProductCommand);
            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteFridgeProductCommand { Id = id };
            await Mediator.Send(command);
            return NoContent();
        }

    }
}
