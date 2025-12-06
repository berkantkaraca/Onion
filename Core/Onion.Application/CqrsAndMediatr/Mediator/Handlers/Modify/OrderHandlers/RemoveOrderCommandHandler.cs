using MediatR;
using Onion.Application.CqrsAndMediatr.Mediator.Commands.OrderCommands;
using Onion.Contract.RepositoryInterfaces;
using Onion.Domain.Entities;

using Onion.Application.CqrsAndMediatr.Mediator.Results.OrderResults;

namespace Onion.Application.CqrsAndMediatr.Mediator.Handlers.Modify.OrderHandlers
{
    public class RemoveOrderCommandHandler : IRequestHandler<RemoveOrderCommand, GetOrderByIdQueryResult>
    {
        private readonly IOrderRepository _repository;

        public RemoveOrderCommandHandler(IOrderRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetOrderByIdQueryResult> Handle(RemoveOrderCommand request, CancellationToken cancellationToken)
        {
            Order value = await _repository.GetByIdAsync(request.Id);
            await _repository.DeleteAsync(value);
            return new GetOrderByIdQueryResult
            {
                Id = value.Id,
                ShippingAddress = value.ShippingAddress,
                AppUserId = value.AppUserId
            };
        }
    }
}
