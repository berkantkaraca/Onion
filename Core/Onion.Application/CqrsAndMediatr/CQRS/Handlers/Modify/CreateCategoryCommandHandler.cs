using Onion.Application.CqrsAndMediatr.CQRS.Commands.CategoryCommands;
using Onion.Contract.RepositoryInterfaces;
using Onion.Domain.Entities;
using Onion.Domain.Enums;

namespace Onion.Application.CqrsAndMediatr.CQRS.Handlers.Modify
{
    public class CreateCategoryCommandHandler
    {
        private readonly ICategoryRepository _repository;

        public CreateCategoryCommandHandler(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateCategoryCommand command)
        {
            await _repository.CreateAsync(new Category
            {
                CategoryName = command.CategoryName,
                Description = command.Description,
                CreatedDate = DateTime.Now,
                Status = DataStatus.Inserted
            });
        }
    }
}
