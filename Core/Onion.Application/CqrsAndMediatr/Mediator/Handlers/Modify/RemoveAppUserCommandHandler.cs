using MediatR;
using Onion.Application.CqrsAndMediatr.Mediator.Commands.AppUserCommands;
using Onion.Contract.RepositoryInterfaces;
using Onion.Domain.Entities;

namespace Onion.Application.CqrsAndMediatr.Mediator.Handlers.Modify
{
    public class RemoveAppUserCommandHandler : IRequestHandler<RemoveAppUserCommand>
    {
        private readonly IAppUserRepository _repository;

        public RemoveAppUserCommandHandler(IAppUserRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveAppUserCommand request, CancellationToken cancellationToken)
        {
            AppUser value = await _repository.GetByIdAsync(request.Id);
            await _repository.DeleteAsync(value);
        }
    }
}
