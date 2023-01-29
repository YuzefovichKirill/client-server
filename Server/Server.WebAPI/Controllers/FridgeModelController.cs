using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Server.Application.FridgeModels.Queries.GetAllFridgeModel;
using Server.Application.FridgeModels.Queries.GetFridgeModel;
using Server.Application.FridgeModels.Commands.CreateFridgeModel;
using Server.Application.FridgeModels.Commands.DeleteFridgeModel;
using Server.Application.FridgeModels.Commands.UpdateFridgeModel;
using Server.WebAPI.Models;

namespace Server.WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class FridgeModelController : BaseController
    {
        private readonly IMapper _mapper;

        public FridgeModelController(IMapper mapper) => _mapper = mapper;

        [HttpGet]
        public async Task<ActionResult<FridgeModelListVm>> GetAll()
        {
            var query = new GetAllFridgeModelQuery();
            var vm = await Mediator.Send(query);
            // change ?
            return Ok(vm.fridgeModels);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<FridgeModelVm>> Get(Guid id)
        {
            var query = new GetFridgeModelQuery() { Id = id };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateFridgeModelCommand createFridgeModelCommand)
        {
            var Id = await Mediator.Send(createFridgeModelCommand);
            return Ok(Id);
        }

        // as example with mapper
        [HttpPut()]
        public async Task<IActionResult> Update([FromBody] UpdateFridgeModelDto updateFridgeModelDto)
        {
            var command = _mapper.Map<UpdateFridgeModelCommand>(updateFridgeModelDto);
            // command.ChangeDate = ...
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteFridgeModelCommand { Id = id };
            await Mediator.Send(command);
            return NoContent();
        }
    }
}