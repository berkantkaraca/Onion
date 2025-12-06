using MediatR;

using Onion.Application.CqrsAndMediatr.Mediator.Results.AppUserProfileResults;

namespace Onion.Application.CqrsAndMediatr.Mediator.Commands.AppUserProfileCommands
{
    public class UpdateAppUserProfileCommand : IRequest<GetAppUserProfileByIdQueryResult>
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int AppUserId { get; set; }
    }
}
