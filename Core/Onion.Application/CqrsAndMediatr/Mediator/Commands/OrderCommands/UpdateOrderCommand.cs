using MediatR;

using Onion.Application.CqrsAndMediatr.Mediator.Results.OrderResults;

namespace Onion.Application.CqrsAndMediatr.Mediator.Commands.OrderCommands
{
    public class UpdateOrderCommand : IRequest<GetOrderByIdQueryResult>
    {
        public int Id { get; set; }
        public string ShippingAddress { get; set; }
        public int? AppUserId { get; set; }
    }
}
