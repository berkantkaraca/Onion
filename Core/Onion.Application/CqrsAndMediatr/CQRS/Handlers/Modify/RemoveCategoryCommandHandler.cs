using Onion.Application.CqrsAndMediatr.CQRS.Commands.CategoryCommands;
using Onion.Contract.RepositoryInterfaces;
using Onion.Domain.Entities;
using Onion.Domain.Enums;

namespace Onion.Application.CqrsAndMediatr.CQRS.Handlers.Modify
{
    public class RemoveCategoryCommandHandler
    {
        private readonly ICategoryRepository _repository;

        public RemoveCategoryCommandHandler(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveCategoryCommand command)
        {
            Category value = await _repository.GetByIdAsync(command.Id);
            
            await _repository.DeleteAsync(value);
        }
    }
}
