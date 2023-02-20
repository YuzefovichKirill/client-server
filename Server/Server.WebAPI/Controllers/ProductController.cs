using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Server.Application.Products.Commands.CreateProduct;
using Server.Application.Products.Commands.DeleteProduct;
using Server.Application.Products.Commands.UpdateProduct;
using Server.Application.Products.Queries.GetAllProduct;
using Server.Application.Products.Queries.GetProduct;

namespace Server.WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class ProductController : BaseController
    {
        private readonly IMapper _mapper;

        public ProductController(IMapper mapper) => _mapper = mapper;
        
        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<ProductListVm>> GetAll()
        {
            var query = new GetAllPRoductQuery();
            var vm = await Mediator.Send(query);
            return Ok(vm.products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Guid>> Get(Guid id)
        {
            var query = new GetProductQuery() { Id = id };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateProductCommand createProductCommand)
        {
            var Id = await Mediator.Send(createProductCommand);
            return Ok(Id);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateProductCommand updateProductCommand)
        {
            await Mediator.Send(updateProductCommand);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteProductCommand { Id = id };
            await Mediator.Send(command);
            return NoContent();
        }

    }
}
