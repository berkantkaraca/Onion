using MediatR;
using Microsoft.AspNetCore.Mvc;
using Onion.Application.CqrsAndMediatr.Mediator.Commands.AppUserCommands;
using Onion.Application.CqrsAndMediatr.Mediator.Queries.AppUserQueries;
using Onion.Application.CqrsAndMediatr.Mediator.Results.AppUserResults;

namespace Onion.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MediatorAppUserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MediatorAppUserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> AppUserList()
        {
            List<GetAppUserQueryResult> appUsers = await _mediator.Send(new GetAppUserQuery());
            return Ok(appUsers);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAppUser(int id)
        {
            GetAppUserByIdQueryResult appUser = await _mediator.Send(new GetAppUserByIdQuery(id));
            return Ok(appUser);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAppUser(CreateAppUserCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAppUser(UpdateAppUserCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAppUser(int id)
        {
            var result = await _mediator.Send(new RemoveAppUserCommand(id));
            return Ok(result);
        }

    }
}
