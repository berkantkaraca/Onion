using MediatR;
using Onion.Application.CqrsAndMediatr.Mediator.Commands.ProductCommands;
using Onion.Contract.RepositoryInterfaces;
using Onion.Domain.Entities;

using Onion.Application.CqrsAndMediatr.Mediator.Results.ProductResults;

namespace Onion.Application.CqrsAndMediatr.Mediator.Handlers.Modify.ProductHandlers
{
    public class RemoveProductCommandHandler : IRequestHandler<RemoveProductCommand, GetProductByIdQueryResult>
    {
        private readonly IProductRepository _repository;

        public RemoveProductCommandHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetProductByIdQueryResult> Handle(RemoveProductCommand request, CancellationToken cancellationToken)
        {
            Product value = await _repository.GetByIdAsync(request.Id);
            await _repository.DeleteAsync(value);
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
