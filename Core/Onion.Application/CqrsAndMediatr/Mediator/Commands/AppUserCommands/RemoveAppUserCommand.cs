using MediatR;

using Onion.Application.CqrsAndMediatr.Mediator.Results.AppUserResults;

namespace Onion.Application.CqrsAndMediatr.Mediator.Commands.AppUserCommands
{
    public class RemoveAppUserCommand : IRequest<GetAppUserByIdQueryResult>
    {
        public int Id { get; set; }

        public RemoveAppUserCommand(int id)
        {
            Id = id;
        }
    }
}
