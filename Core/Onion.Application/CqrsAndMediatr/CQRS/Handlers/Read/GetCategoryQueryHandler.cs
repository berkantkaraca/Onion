using Onion.Application.CqrsAndMediatr.CQRS.Results.CategoryResult;
using Onion.Contract.RepositoryInterfaces;
using Onion.Domain.Entities;

namespace Onion.Application.CqrsAndMediatr.CQRS.Handlers.Read
{
    public class GetCategoryQueryHandler
    {
        private readonly ICategoryRepository _repository;

        public GetCategoryQueryHandler (ICategoryRepository repository)
        {
            _repository = repository;
        }

        //TODO: Mapper profiles ödev

        public async Task<List<GetCategoryQueryResult>> Handle()
        {
            List<Category> values = await _repository.GetAllAsync();

            return values.Select(x => new GetCategoryQueryResult
            {
                CategoryName = x.CategoryName,
                Description = x.Description,
                Id = x.Id
            }).ToList();
        }
    }
}
