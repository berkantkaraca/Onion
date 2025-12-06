using MediatR;

using Onion.Application.CqrsAndMediatr.Mediator.Results.OrderDetailResults;

namespace Onion.Application.CqrsAndMediatr.Mediator.Commands.OrderDetailCommands
{
    public class CreateOrderDetailCommand : IRequest<GetOrderDetailByIdQueryResult>
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
    }
}
