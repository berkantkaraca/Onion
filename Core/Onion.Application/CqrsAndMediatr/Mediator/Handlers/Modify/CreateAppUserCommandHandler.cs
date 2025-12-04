using MediatR;
using Onion.Application.CqrsAndMediatr.Mediator.Commands.AppUserCommands;
using Onion.Contract.RepositoryInterfaces;
using Onion.Domain.Entities;

namespace Onion.Application.CqrsAndMediatr.Mediator.Handlers.Modify
{
    public class CreateAppUserCommandHandler : IRequestHandler<CreateAppUserCommand>
    {
        private readonly IAppUserRepository _repository;

        public CreateAppUserCommandHandler(IAppUserRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateAppUserCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new AppUser
            {
                UserName = request.UserName,
                Password = request.Password
            });
        }
    }
}
