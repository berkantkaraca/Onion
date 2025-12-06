using MediatR;

using Onion.Application.CqrsAndMediatr.Mediator.Results.AppUserResults;

namespace Onion.Application.CqrsAndMediatr.Mediator.Commands.AppUserCommands
{
    public class UpdateAppUserCommand : IRequest<GetAppUserByIdQueryResult>
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
