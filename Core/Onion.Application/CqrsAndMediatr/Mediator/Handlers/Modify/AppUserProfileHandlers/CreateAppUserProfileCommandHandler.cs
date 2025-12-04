using MediatR;
using Onion.Application.CqrsAndMediatr.Mediator.Commands.AppUserProfileCommands;
using Onion.Contract.RepositoryInterfaces;
using Onion.Domain.Entities;

namespace Onion.Application.CqrsAndMediatr.Mediator.Handlers.Modify.AppUserProfileHandlers
{
    public class CreateAppUserProfileCommandHandler : IRequestHandler<CreateAppUserProfileCommand>
    {
        private readonly IAppUserProfileRepository _repository;

        public CreateAppUserProfileCommandHandler(IAppUserProfileRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateAppUserProfileCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new AppUserProfile
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                AppUserId = request.AppUserId
            });
        }
    }
}
