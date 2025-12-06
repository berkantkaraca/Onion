using MediatR;
using Onion.Application.CqrsAndMediatr.Mediator.Commands.CategoryCommands;
using Onion.Contract.RepositoryInterfaces;
using Onion.Domain.Entities;

using Onion.Application.CqrsAndMediatr.Mediator.Results.CategoryResults;

namespace Onion.Application.CqrsAndMediatr.Mediator.Handlers.Modify.CategoryHandlers
{
    public class RemoveCategoryCommandHandler : IRequestHandler<RemoveCategoryCommand, GetCategoryByIdQueryResult>
    {
        private readonly ICategoryRepository _repository;

        public RemoveCategoryCommandHandler(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetCategoryByIdQueryResult> Handle(RemoveCategoryCommand request, CancellationToken cancellationToken)
        {
            Category value = await _repository.GetByIdAsync(request.Id);
            await _repository.DeleteAsync(value);
            return new GetCategoryByIdQueryResult
            {
                Id = value.Id,
                CategoryName = value.CategoryName,
                Description = value.Description
            };
        }
    }
}
