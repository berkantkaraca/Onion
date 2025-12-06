using MediatR;
using Onion.Application.CqrsAndMediatr.Mediator.Commands.ProductCommands;
using Onion.Contract.RepositoryInterfaces;
using Onion.Domain.Entities;

using Onion.Application.CqrsAndMediatr.Mediator.Results.ProductResults;

namespace Onion.Application.CqrsAndMediatr.Mediator.Handlers.Modify.ProductHandlers
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, GetProductByIdQueryResult>
    {
        private readonly IProductRepository _repository;

        public CreateProductCommandHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetProductByIdQueryResult> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = new Product
            {
                ProductName = request.ProductName,
                UnitPrice = request.UnitPrice,
                CategoryId = request.CategoryId
            };
            await _repository.CreateAsync(product);
            return new GetProductByIdQueryResult
            {
                Id = product.Id,
                ProductName = product.ProductName,
                UnitPrice = product.UnitPrice,
                CategoryId = product.CategoryId
            };
        }
    }
}
