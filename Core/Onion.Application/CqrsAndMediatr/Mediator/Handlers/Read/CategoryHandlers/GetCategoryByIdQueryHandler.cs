using MediatR;
using Onion.Application.CqrsAndMediatr.Mediator.Queries.CategoryQueries;
using Onion.Application.CqrsAndMediatr.Mediator.Results.CategoryResults;
using Onion.Contract.RepositoryInterfaces;
using Onion.Domain.Entities;

namespace Onion.Application.CqrsAndMediatr.Mediator.Handlers.Read.CategoryHandlers
{
    public class GetCategoryByIdQueryHandler : IRequestHandler<GetCategoryByIdQuery, GetCategoryByIdQueryResult>
    {
        private readonly ICategoryRepository _repository;

        public GetCategoryByIdQueryHandler(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetCategoryByIdQueryResult> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            Category value = await _repository.GetByIdAsync(request.Id);
            return new GetCategoryByIdQueryResult
            {
                Id = value.Id,
                CategoryName = value.CategoryName,
                Description = value.Description
            };
        }
    }
}
