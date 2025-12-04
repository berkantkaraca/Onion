using MediatR;
using Onion.Application.CqrsAndMediatr.Mediator.Results.OrderResults;

namespace Onion.Application.CqrsAndMediatr.Mediator.Queries.OrderQueries
{
    public class GetOrderByIdQuery : IRequest<GetOrderByIdQueryResult>
    {
        public int Id { get; set; }

        public GetOrderByIdQuery(int id)
        {
            Id = id;
        }
    }
}
