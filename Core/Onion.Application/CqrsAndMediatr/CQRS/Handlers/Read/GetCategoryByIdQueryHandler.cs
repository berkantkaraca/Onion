using Onion.Application.CqrsAndMediatr.CQRS.Queries.CategoryQueries;
using Onion.Application.CqrsAndMediatr.CQRS.Results.CategoryResult;
using Onion.Contract.RepositoryInterfaces;
using Onion.Domain.Entities;

namespace Onion.Application.CqrsAndMediatr.CQRS.Handlers.Read
{
    public class GetCategoryByIdQueryHandler
    {
        private readonly ICategoryRepository _repository;

        public GetCategoryByIdQueryHandler(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetCategoryByIdQueryResult> Handle(GetCategoryByIdQuery query)
        {
            Category value = await _repository.GetByIdAsync(query.Id);

            return new GetCategoryByIdQueryResult
            {
                CategoryName = value.CategoryName,
                Description = value.Description,
                Id = value.Id
            };
        }
    }
}
