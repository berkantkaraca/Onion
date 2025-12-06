using MediatR;

using Onion.Application.CqrsAndMediatr.Mediator.Results.ProductResults;

namespace Onion.Application.CqrsAndMediatr.Mediator.Commands.ProductCommands
{
    public class CreateProductCommand : IRequest<GetProductByIdQueryResult>
    {
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public int? CategoryId { get; set; }
    }
}
