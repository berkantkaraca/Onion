using MediatR;
using Onion.Application.CqrsAndMediatr.Mediator.Commands.AppUserCommands;
using Onion.Contract.RepositoryInterfaces;
using Onion.Domain.Entities;
using Onion.Domain.Enums;

namespace Onion.Application.CqrsAndMediatr.Mediator.Handlers.Modify
{
    public class UpdateAppUserCommandHandler : IRequestHandler<UpdateAppUserCommand>
    {
        private readonly IAppUserRepository _repository;

        public UpdateAppUserCommandHandler(IAppUserRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateAppUserCommand request, CancellationToken cancellationToken)
        {
            AppUser value = await _repository.GetByIdAsync(request.Id);

            value.UserName = request.UserName;
            value.Password = request.Password;
            value.Status = DataStatus.Updated;
            value.UpdatedDate = DateTime.Now;

            await _repository.SaveChangesAsync();
        }
    }
}
