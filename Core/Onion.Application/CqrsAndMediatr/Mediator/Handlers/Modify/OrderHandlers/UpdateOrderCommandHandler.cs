using MediatR;
using Onion.Application.CqrsAndMediatr.Mediator.Commands.OrderCommands;
using Onion.Contract.RepositoryInterfaces;
using Onion.Domain.Entities;
using Onion.Domain.Enums;

using Onion.Application.CqrsAndMediatr.Mediator.Results.OrderResults;

namespace Onion.Application.CqrsAndMediatr.Mediator.Handlers.Modify.OrderHandlers
{
    public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand, GetOrderByIdQueryResult>
    {
        private readonly IOrderRepository _repository;

        public UpdateOrderCommandHandler(IOrderRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetOrderByIdQueryResult> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            Order value = await _repository.GetByIdAsync(request.Id);

            value.ShippingAddress = request.ShippingAddress;
            value.AppUserId = request.AppUserId;
            value.Status = DataStatus.Updated;
            value.UpdatedDate = DateTime.Now;

            await _repository.SaveChangesAsync();
            return new GetOrderByIdQueryResult
            {
                Id = value.Id,
                ShippingAddress = value.ShippingAddress,
                AppUserId = value.AppUserId
            };
        }
    }
}
