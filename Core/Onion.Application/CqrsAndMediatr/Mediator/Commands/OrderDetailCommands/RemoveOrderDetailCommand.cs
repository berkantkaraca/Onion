using MediatR;

using Onion.Application.CqrsAndMediatr.Mediator.Results.OrderDetailResults;

namespace Onion.Application.CqrsAndMediatr.Mediator.Commands.OrderDetailCommands
{
    public class RemoveOrderDetailCommand : IRequest<GetOrderDetailByIdQueryResult>
    {
        public int Id { get; set; }

        public RemoveOrderDetailCommand(int id)
        {
            Id = id;
        }
    }
}
