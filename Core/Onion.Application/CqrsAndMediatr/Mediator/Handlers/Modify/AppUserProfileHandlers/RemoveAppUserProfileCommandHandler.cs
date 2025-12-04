using MediatR;
using Onion.Application.CqrsAndMediatr.Mediator.Commands.AppUserProfileCommands;
using Onion.Contract.RepositoryInterfaces;
using Onion.Domain.Entities;

namespace Onion.Application.CqrsAndMediatr.Mediator.Handlers.Modify.AppUserProfileHandlers
{
    public class RemoveAppUserProfileCommandHandler : IRequestHandler<RemoveAppUserProfileCommand>
    {
        private readonly IAppUserProfileRepository _repository;

        public RemoveAppUserProfileCommandHandler(IAppUserProfileRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveAppUserProfileCommand request, CancellationToken cancellationToken)
        {
            AppUserProfile value = await _repository.GetByIdAsync(request.Id);
            await _repository.DeleteAsync(value);
        }
    }
}
