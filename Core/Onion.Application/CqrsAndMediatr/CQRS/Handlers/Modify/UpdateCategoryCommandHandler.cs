using Onion.Application.CqrsAndMediatr.CQRS.Commands.CategoryCommands;
using Onion.Contract.RepositoryInterfaces;
using Onion.Domain.Entities;
using Onion.Domain.Enums;

namespace Onion.Application.CqrsAndMediatr.CQRS.Handlers.Modify
{
    public class UpdateCategoryCommandHandler
    {
        private readonly ICategoryRepository _repository;

        public UpdateCategoryCommandHandler(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateCategoryCommand command)
        {
            Category value  = await _repository.GetByIdAsync(command.Id);
            
            value.CategoryName = command.CategoryName;
            value.Description = command.Description;
            value.UpdatedDate = DateTime.Now;
            value.Status = DataStatus.Updated;

            await _repository.SaveChangesAsync();
        }
    }
}
