using MediatR;
using Microsoft.AspNetCore.Mvc;
using Onion.Application.CqrsAndMediatr.Mediator.Commands.CategoryCommands;
using Onion.Application.CqrsAndMediatr.Mediator.Queries.CategoryQueries;
using Onion.Application.CqrsAndMediatr.Mediator.Results.CategoryResults;

namespace Onion.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MediatorCategoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MediatorCategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> CategoryList()
        {
            List<GetCategoryQueryResult> values = await _mediator.Send(new GetCategoryQuery());
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategory(int id)
        {
            GetCategoryByIdQueryResult value = await _mediator.Send(new GetCategoryByIdQuery(id));
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var result = await _mediator.Send(new RemoveCategoryCommand(id));
            return Ok(result);
        }
    }
}
