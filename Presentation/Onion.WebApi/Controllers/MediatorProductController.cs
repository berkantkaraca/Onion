using MediatR;
using Microsoft.AspNetCore.Mvc;
using Onion.Application.CqrsAndMediatr.Mediator.Commands.ProductCommands;
using Onion.Application.CqrsAndMediatr.Mediator.Queries.ProductQueries;
using Onion.Application.CqrsAndMediatr.Mediator.Results.ProductResults;

namespace Onion.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MediatorProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MediatorProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> ProductList()
        {
            List<GetProductQueryResult> values = await _mediator.Send(new GetProductQuery());
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            GetProductByIdQueryResult value = await _mediator.Send(new GetProductByIdQuery(id));
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductCommand command)
        {
            await _mediator.Send(command);
            return Ok("Product eklendi.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct(UpdateProductCommand command)
        {
            await _mediator.Send(command);
            return Ok("Product guncellendi.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            await _mediator.Send(new RemoveProductCommand(id));
            return Ok("Product silindi.");
        }
    }
}
