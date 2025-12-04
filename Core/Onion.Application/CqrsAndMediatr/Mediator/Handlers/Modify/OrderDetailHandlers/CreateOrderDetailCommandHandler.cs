using MediatR;
using Onion.Application.CqrsAndMediatr.Mediator.Commands.OrderDetailCommands;
using Onion.Contract.RepositoryInterfaces;
using Onion.Domain.Entities;

namespace Onion.Application.CqrsAndMediatr.Mediator.Handlers.Modify.OrderDetailHandlers
{
    public class CreateOrderDetailCommandHandler : IRequestHandler<CreateOrderDetailCommand>
    {
        private readonly IOrderDetailRepository _repository;

        public CreateOrderDetailCommandHandler(IOrderDetailRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateOrderDetailCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new OrderDetail
            {
                OrderId = request.OrderId,
                ProductId = request.ProductId
            });
        }
    }
}
