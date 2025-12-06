using MediatR;
using Microsoft.AspNetCore.Mvc;
using Onion.Application.CqrsAndMediatr.Mediator.Commands.OrderCommands;
using Onion.Application.CqrsAndMediatr.Mediator.Queries.OrderQueries;
using Onion.Application.CqrsAndMediatr.Mediator.Results.OrderResults;

namespace Onion.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MediatorOrderController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MediatorOrderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> OrderList()
        {
            List<GetOrderQueryResult> values = await _mediator.Send(new GetOrderQuery());
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrder(int id)
        {
            GetOrderByIdQueryResult value = await _mediator.Send(new GetOrderByIdQuery(id));
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder(CreateOrderCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateOrder(UpdateOrderCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            var result = await _mediator.Send(new RemoveOrderCommand(id));
            return Ok(result);
        }
    }
}
