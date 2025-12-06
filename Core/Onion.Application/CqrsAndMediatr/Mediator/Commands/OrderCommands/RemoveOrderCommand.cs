using MediatR;

using Onion.Application.CqrsAndMediatr.Mediator.Results.OrderResults;

namespace Onion.Application.CqrsAndMediatr.Mediator.Commands.OrderCommands
{
    public class RemoveOrderCommand : IRequest<GetOrderByIdQueryResult>
    {
        public int Id { get; set; }

        public RemoveOrderCommand(int id)
        {
            Id = id;
        }
    }
}
