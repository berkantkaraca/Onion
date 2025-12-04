using MediatR;
using Onion.Application.CqrsAndMediatr.Mediator.Results.ProductResults;

namespace Onion.Application.CqrsAndMediatr.Mediator.Queries.ProductQueries
{
    public class GetProductByIdQuery : IRequest<GetProductByIdQueryResult>
    {
        public int Id { get; set; }

        public GetProductByIdQuery(int id)
        {
            Id = id;
        }
    }
}
