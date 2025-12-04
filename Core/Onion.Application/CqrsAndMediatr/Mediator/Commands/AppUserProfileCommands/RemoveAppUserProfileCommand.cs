using MediatR;

namespace Onion.Application.CqrsAndMediatr.Mediator.Commands.AppUserProfileCommands
{
    public class RemoveAppUserProfileCommand : IRequest
    {
        public int Id { get; set; }

        public RemoveAppUserProfileCommand(int id)
        {
            Id = id;
        }
    }
}
