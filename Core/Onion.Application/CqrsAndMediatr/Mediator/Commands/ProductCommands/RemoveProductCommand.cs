using MediatR;

namespace Onion.Application.CqrsAndMediatr.Mediator.Commands.ProductCommands
{
    public class RemoveProductCommand : IRequest
    {
        public int Id { get; set; }

        public RemoveProductCommand(int id)
        {
            Id = id;
        }
    }
}
