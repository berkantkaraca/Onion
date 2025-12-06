using MediatR;
using Onion.Application.CqrsAndMediatr.Mediator.Commands.AppUserProfileCommands;
using Onion.Contract.RepositoryInterfaces;
using Onion.Domain.Entities;
using Onion.Domain.Enums;

using Onion.Application.CqrsAndMediatr.Mediator.Results.AppUserProfileResults;

namespace Onion.Application.CqrsAndMediatr.Mediator.Handlers.Modify.AppUserProfileHandlers
{
    public class UpdateAppUserProfileCommandHandler : IRequestHandler<UpdateAppUserProfileCommand, GetAppUserProfileByIdQueryResult>
    {
        private readonly IAppUserProfileRepository _repository;

        public UpdateAppUserProfileCommandHandler(IAppUserProfileRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetAppUserProfileByIdQueryResult> Handle(UpdateAppUserProfileCommand request, CancellationToken cancellationToken)
        {
            AppUserProfile value = await _repository.GetByIdAsync(request.Id);

            value.FirstName = request.FirstName;
            value.LastName = request.LastName;
            value.AppUserId = request.AppUserId;
            value.Status = DataStatus.Updated;
            value.UpdatedDate = DateTime.Now;

            await _repository.SaveChangesAsync();
            return new GetAppUserProfileByIdQueryResult
            {
                Id = value.Id,
                FirstName = value.FirstName,
                LastName = value.LastName,
                AppUserId = value.AppUserId
            };
        }
    }
}
