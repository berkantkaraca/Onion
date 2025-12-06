using MediatR;
using Onion.Application.CqrsAndMediatr.Mediator.Commands.AppUserProfileCommands;
using Onion.Contract.RepositoryInterfaces;
using Onion.Domain.Entities;

using Onion.Application.CqrsAndMediatr.Mediator.Results.AppUserProfileResults;

namespace Onion.Application.CqrsAndMediatr.Mediator.Handlers.Modify.AppUserProfileHandlers
{
    public class CreateAppUserProfileCommandHandler : IRequestHandler<CreateAppUserProfileCommand, GetAppUserProfileByIdQueryResult>
    {
        private readonly IAppUserProfileRepository _repository;

        public CreateAppUserProfileCommandHandler(IAppUserProfileRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetAppUserProfileByIdQueryResult> Handle(CreateAppUserProfileCommand request, CancellationToken cancellationToken)
        {
            var appUserProfile = new AppUserProfile
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                AppUserId = request.AppUserId
            };
            await _repository.CreateAsync(appUserProfile);
            return new GetAppUserProfileByIdQueryResult
            {
                Id = appUserProfile.Id,
                FirstName = appUserProfile.FirstName,
                LastName = appUserProfile.LastName,
                AppUserId = appUserProfile.AppUserId
            };
        }
    }
}
