using MediatR;
using Onion.Application.CqrsAndMediatr.Mediator.Commands.AppUserCommands;
using Onion.Contract.RepositoryInterfaces;
using Onion.Domain.Entities;

using Onion.Application.CqrsAndMediatr.Mediator.Results.AppUserResults;

namespace Onion.Application.CqrsAndMediatr.Mediator.Handlers.Modify.AppUserHandlers
{
    public class RemoveAppUserCommandHandler : IRequestHandler<RemoveAppUserCommand, GetAppUserByIdQueryResult>
    {
        private readonly IAppUserRepository _repository;

        public RemoveAppUserCommandHandler(IAppUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetAppUserByIdQueryResult> Handle(RemoveAppUserCommand request, CancellationToken cancellationToken)
        {
            AppUser value = await _repository.GetByIdAsync(request.Id);
            await _repository.DeleteAsync(value);
            return new GetAppUserByIdQueryResult
            {
                Id = value.Id,
                UserName = value.UserName,
                Password = value.Password
            };
        }
    }
}
