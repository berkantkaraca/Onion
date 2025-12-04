using MediatR;
using Onion.Application.CqrsAndMediatr.Mediator.Queries.ProductQueries;
using Onion.Application.CqrsAndMediatr.Mediator.Results.ProductResults;
using Onion.Contract.RepositoryInterfaces;
using Onion.Domain.Entities;

namespace Onion.Application.CqrsAndMediatr.Mediator.Handlers.Read.ProductHandlers
{
    public class GetProductQueryHandler : IRequestHandler<GetProductQuery, List<GetProductQueryResult>>
    {
        private readonly IProductRepository _repository;

        public GetProductQueryHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetProductQueryResult>> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            List<Product> values = await _repository.GetAllAsync();
            return values.Select(x => new GetProductQueryResult
            {
                Id = x.Id,
                ProductName = x.ProductName,
                UnitPrice = x.UnitPrice,
                CategoryId = x.CategoryId
            }).ToList();
        }
    }
}
