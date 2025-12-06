using MediatR;
using Onion.Application.CqrsAndMediatr.Mediator.Commands.OrderDetailCommands;
using Onion.Contract.RepositoryInterfaces;
using Onion.Domain.Entities;

using Onion.Application.CqrsAndMediatr.Mediator.Results.OrderDetailResults;

namespace Onion.Application.CqrsAndMediatr.Mediator.Handlers.Modify.OrderDetailHandlers
{
    public class CreateOrderDetailCommandHandler : IRequestHandler<CreateOrderDetailCommand, GetOrderDetailByIdQueryResult>
    {
        private readonly IOrderDetailRepository _repository;

        public CreateOrderDetailCommandHandler(IOrderDetailRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetOrderDetailByIdQueryResult> Handle(CreateOrderDetailCommand request, CancellationToken cancellationToken)
        {
            var orderDetail = new OrderDetail
            {
                OrderId = request.OrderId,
                ProductId = request.ProductId
            };
            await _repository.CreateAsync(orderDetail);
            return new GetOrderDetailByIdQueryResult
            {
                Id = orderDetail.Id,
                OrderId = orderDetail.OrderId,
                ProductId = orderDetail.ProductId
            };
        }
    }
}
