using MediatR;
using Onion.Application.CqrsAndMediatr.Mediator.Commands.ProductCommands;
using Onion.Contract.RepositoryInterfaces;
using Onion.Domain.Entities;

namespace Onion.Application.CqrsAndMediatr.Mediator.Handlers.Modify.ProductHandlers
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand>
    {
        private readonly IProductRepository _repository;

        public CreateProductCommandHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new Product
            {
                ProductName = request.ProductName,
                UnitPrice = request.UnitPrice,
                CategoryId = request.CategoryId
            });
        }
    }
}
