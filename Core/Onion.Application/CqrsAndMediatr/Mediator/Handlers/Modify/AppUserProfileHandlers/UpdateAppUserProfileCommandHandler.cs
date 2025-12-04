using MediatR;
using Onion.Application.CqrsAndMediatr.Mediator.Commands.AppUserProfileCommands;
using Onion.Contract.RepositoryInterfaces;
using Onion.Domain.Entities;
using Onion.Domain.Enums;

namespace Onion.Application.CqrsAndMediatr.Mediator.Handlers.Modify.AppUserProfileHandlers
{
    public class UpdateAppUserProfileCommandHandler : IRequestHandler<UpdateAppUserProfileCommand>
    {
        private readonly IAppUserProfileRepository _repository;

        public UpdateAppUserProfileCommandHandler(IAppUserProfileRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateAppUserProfileCommand request, CancellationToken cancellationToken)
        {
            AppUserProfile value = await _repository.GetByIdAsync(request.Id);

            value.FirstName = request.FirstName;
            value.LastName = request.LastName;
            value.AppUserId = request.AppUserId;
            value.Status = DataStatus.Updated;
            value.UpdatedDate = DateTime.Now;

            await _repository.SaveChangesAsync();
        }
    }
}
