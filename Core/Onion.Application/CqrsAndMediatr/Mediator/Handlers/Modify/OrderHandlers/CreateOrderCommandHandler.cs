using MediatR;
using Onion.Application.CqrsAndMediatr.Mediator.Commands.OrderCommands;
using Onion.Contract.RepositoryInterfaces;
using Onion.Domain.Entities;

using Onion.Application.CqrsAndMediatr.Mediator.Results.OrderResults;

namespace Onion.Application.CqrsAndMediatr.Mediator.Handlers.Modify.OrderHandlers
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, GetOrderByIdQueryResult>
    {
        private readonly IOrderRepository _repository;

        public CreateOrderCommandHandler(IOrderRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetOrderByIdQueryResult> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = new Order
            {
                ShippingAddress = request.ShippingAddress,
                AppUserId = request.AppUserId
            };
            await _repository.CreateAsync(order);
            return new GetOrderByIdQueryResult
            {
                Id = order.Id,
                ShippingAddress = order.ShippingAddress,
                AppUserId = order.AppUserId
            };
        }
    }
}
