using MediatR;

namespace Onion.Application.CqrsAndMediatr.Mediator.Commands.OrderDetailCommands
{
    public class UpdateOrderDetailCommand : IRequest
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
    }
}
