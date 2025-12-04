using MediatR;
using Onion.Application.CqrsAndMediatr.Mediator.Commands.OrderDetailCommands;
using Onion.Contract.RepositoryInterfaces;
using Onion.Domain.Entities;
using Onion.Domain.Enums;

namespace Onion.Application.CqrsAndMediatr.Mediator.Handlers.Modify.OrderDetailHandlers
{
    public class UpdateOrderDetailCommandHandler : IRequestHandler<UpdateOrderDetailCommand>
    {
        private readonly IOrderDetailRepository _repository;

        public UpdateOrderDetailCommandHandler(IOrderDetailRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateOrderDetailCommand request, CancellationToken cancellationToken)
        {
            OrderDetail value = await _repository.GetByIdAsync(request.Id);

            value.OrderId = request.OrderId;
            value.ProductId = request.ProductId;
            value.Status = DataStatus.Updated;
            value.UpdatedDate = DateTime.Now;

            await _repository.SaveChangesAsync();
        }
    }
}
