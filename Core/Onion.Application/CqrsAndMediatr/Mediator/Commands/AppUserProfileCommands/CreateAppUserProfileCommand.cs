using MediatR;

using Onion.Application.CqrsAndMediatr.Mediator.Results.AppUserProfileResults;

namespace Onion.Application.CqrsAndMediatr.Mediator.Commands.AppUserProfileCommands
{
    public class CreateAppUserProfileCommand : IRequest<GetAppUserProfileByIdQueryResult>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int AppUserId { get; set; }
    }
}
