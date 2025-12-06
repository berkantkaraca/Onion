using MediatR;

using Onion.Application.CqrsAndMediatr.Mediator.Results.ProductResults;

namespace Onion.Application.CqrsAndMediatr.Mediator.Commands.ProductCommands
{
    public class RemoveProductCommand : IRequest<GetProductByIdQueryResult>
    {
        public int Id { get; set; }

        public RemoveProductCommand(int id)
        {
            Id = id;
        }
    }
}
