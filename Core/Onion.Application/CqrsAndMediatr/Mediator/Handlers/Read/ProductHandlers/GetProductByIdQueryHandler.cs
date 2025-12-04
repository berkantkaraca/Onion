using MediatR;
using Onion.Application.CqrsAndMediatr.Mediator.Queries.ProductQueries;
using Onion.Application.CqrsAndMediatr.Mediator.Results.ProductResults;
using Onion.Contract.RepositoryInterfaces;
using Onion.Domain.Entities;

namespace Onion.Application.CqrsAndMediatr.Mediator.Handlers.Read.ProductHandlers
{
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, GetProductByIdQueryResult>
    {
        private readonly IProductRepository _repository;

        public GetProductByIdQueryHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetProductByIdQueryResult> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            Product value = await _repository.GetByIdAsync(request.Id);
            return new GetProductByIdQueryResult
            {
                Id = value.Id,
                ProductName = value.ProductName,
                UnitPrice = value.UnitPrice,
                CategoryId = value.CategoryId
            };
        }
    }
}
