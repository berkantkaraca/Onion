using MediatR;
using Onion.Application.CqrsAndMediatr.Mediator.Commands.CategoryCommands;
using Onion.Contract.RepositoryInterfaces;
using Onion.Domain.Entities;

using Onion.Application.CqrsAndMediatr.Mediator.Results.CategoryResults;

namespace Onion.Application.CqrsAndMediatr.Mediator.Handlers.Modify.CategoryHandlers
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, GetCategoryByIdQueryResult>
    {
        private readonly ICategoryRepository _repository;

        public CreateCategoryCommandHandler(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetCategoryByIdQueryResult> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = new Category
            {
                CategoryName = request.CategoryName,
                Description = request.Description
            };
            await _repository.CreateAsync(category);
            return new GetCategoryByIdQueryResult
            {
                Id = category.Id,
                CategoryName = category.CategoryName,
                Description = category.Description
            };
        }
    }
}
