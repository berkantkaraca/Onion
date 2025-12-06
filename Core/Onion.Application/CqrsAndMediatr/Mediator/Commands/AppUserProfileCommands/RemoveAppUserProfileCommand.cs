using MediatR;

using Onion.Application.CqrsAndMediatr.Mediator.Results.AppUserProfileResults;

namespace Onion.Application.CqrsAndMediatr.Mediator.Commands.AppUserProfileCommands
{
    public class RemoveAppUserProfileCommand : IRequest<GetAppUserProfileByIdQueryResult>
    {
        public int Id { get; set; }

        public RemoveAppUserProfileCommand(int id)
        {
            Id = id;
        }
    }
}
