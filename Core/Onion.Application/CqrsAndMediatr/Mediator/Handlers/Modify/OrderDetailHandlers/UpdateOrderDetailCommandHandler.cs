using MediatR;
using Onion.Application.CqrsAndMediatr.Mediator.Commands.OrderDetailCommands;
using Onion.Contract.RepositoryInterfaces;
using Onion.Domain.Entities;
using Onion.Domain.Enums;

using Onion.Application.CqrsAndMediatr.Mediator.Results.OrderDetailResults;

namespace Onion.Application.CqrsAndMediatr.Mediator.Handlers.Modify.OrderDetailHandlers
{
    public class UpdateOrderDetailCommandHandler : IRequestHandler<UpdateOrderDetailCommand, GetOrderDetailByIdQueryResult>
    {
        private readonly IOrderDetailRepository _repository;

        public UpdateOrderDetailCommandHandler(IOrderDetailRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetOrderDetailByIdQueryResult> Handle(UpdateOrderDetailCommand request, CancellationToken cancellationToken)
        {
            OrderDetail value = await _repository.GetByIdAsync(request.Id);

            value.OrderId = request.OrderId;
            value.ProductId = request.ProductId;
            value.Status = DataStatus.Updated;
            value.UpdatedDate = DateTime.Now;

            await _repository.SaveChangesAsync();
            return new GetOrderDetailByIdQueryResult
            {
                Id = value.Id,
                OrderId = value.OrderId,
                ProductId = value.ProductId
            };
        }
    }
}
