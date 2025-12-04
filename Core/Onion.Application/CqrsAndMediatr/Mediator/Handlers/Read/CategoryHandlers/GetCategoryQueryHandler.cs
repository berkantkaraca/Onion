using MediatR;
using Onion.Application.CqrsAndMediatr.Mediator.Queries.CategoryQueries;
using Onion.Application.CqrsAndMediatr.Mediator.Results.CategoryResults;
using Onion.Contract.RepositoryInterfaces;
using Onion.Domain.Entities;

namespace Onion.Application.CqrsAndMediatr.Mediator.Handlers.Read.CategoryHandlers
{
    public class GetCategoryQueryHandler : IRequestHandler<GetCategoryQuery, List<GetCategoryQueryResult>>
    {
        private readonly ICategoryRepository _repository;

        public GetCategoryQueryHandler(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetCategoryQueryResult>> Handle(GetCategoryQuery request, CancellationToken cancellationToken)
        {
            List<Category> values = await _repository.GetAllAsync();
            return values.Select(x => new GetCategoryQueryResult
            {
                Id = x.Id,
                CategoryName = x.CategoryName,
                Description = x.Description
            }).ToList();
        }
    }
}
