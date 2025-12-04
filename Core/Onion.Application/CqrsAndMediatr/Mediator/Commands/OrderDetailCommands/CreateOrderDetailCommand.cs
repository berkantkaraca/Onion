using MediatR;

namespace Onion.Application.CqrsAndMediatr.Mediator.Commands.OrderDetailCommands
{
    public class CreateOrderDetailCommand : IRequest
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
    }
}
