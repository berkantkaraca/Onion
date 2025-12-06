using MediatR;
using Onion.Application.CqrsAndMediatr.Mediator.Commands.AppUserCommands;
using Onion.Contract.RepositoryInterfaces;
using Onion.Domain.Entities;

using Onion.Application.CqrsAndMediatr.Mediator.Results.AppUserResults;

namespace Onion.Application.CqrsAndMediatr.Mediator.Handlers.Modify.AppUserHandlers
{
    public class CreateAppUserCommandHandler : IRequestHandler<CreateAppUserCommand, GetAppUserByIdQueryResult>
    {
        private readonly IAppUserRepository _repository;

        public CreateAppUserCommandHandler(IAppUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetAppUserByIdQueryResult> Handle(CreateAppUserCommand request, CancellationToken cancellationToken)
        {
            var appUser = new AppUser
            {
                UserName = request.UserName,
                Password = request.Password
            };
            await _repository.CreateAsync(appUser);
            return new GetAppUserByIdQueryResult
            {
                Id = appUser.Id,
                UserName = appUser.UserName,
                Password = appUser.Password
            };
        }
    }
}
