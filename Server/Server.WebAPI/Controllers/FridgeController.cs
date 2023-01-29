using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Server.Application.Fridges.Commands.CreateFridge;
using Server.Application.Fridges.Commands.DeleteFridge;
using Server.Application.Fridges.Commands.UpdateFridge;
using Server.Application.Fridges.Queries.GetAllFridge;
using Server.Application.Fridges.Queries.GetFridge;

namespace Server.WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class FridgeController : BaseController
    {
        private readonly IMapper _mapper;

        public FridgeController(IMapper mapper) => _mapper = mapper;

        [HttpGet]
        public async Task<ActionResult<FridgeListVm>> GetAll()
        {
            var query = new GetAllFridgeQuery();
            var vm = await Mediator.Send(query);
            return Ok(vm.fridges);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Guid>> Get(Guid id)
        {
            var query = new GetFridgeQuery() { Id = id };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateFridgeCommand createFridgeCommand)
        {
            var Id = await Mediator.Send(createFridgeCommand);
            return Ok(Id);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateFridgeCommand updateFridgeCommand)
        {
            await Mediator.Send(updateFridgeCommand);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteFridgeCommand { Id = id };
            await Mediator.Send(command);
            return NoContent();
        }

    }
}
