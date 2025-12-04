using MediatR;

namespace Onion.Application.CqrsAndMediatr.Mediator.Commands.OrderCommands
{
    public class RemoveOrderCommand : IRequest
    {
        public int Id { get; set; }

        public RemoveOrderCommand(int id)
        {
            Id = id;
        }
    }
}
