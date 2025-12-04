using MediatR;
using Onion.Application.CqrsAndMediatr.Mediator.Commands.ProductCommands;
using Onion.Contract.RepositoryInterfaces;
using Onion.Domain.Entities;
using Onion.Domain.Enums;

namespace Onion.Application.CqrsAndMediatr.Mediator.Handlers.Modify.ProductHandlers
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand>
    {
        private readonly IProductRepository _repository;

        public UpdateProductCommandHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            Product value = await _repository.GetByIdAsync(request.Id);

            value.ProductName = request.ProductName;
            value.UnitPrice = request.UnitPrice;
            value.CategoryId = request.CategoryId;
            value.Status = DataStatus.Updated;
            value.UpdatedDate = DateTime.Now;

            await _repository.SaveChangesAsync();
        }
    }
}
