using MediatR;
using Onion.Application.CqrsAndMediatr.Mediator.Results.OrderDetailResults;

namespace Onion.Application.CqrsAndMediatr.Mediator.Queries.OrderDetailQueries
{
    public class GetOrderDetailByIdQuery : IRequest<GetOrderDetailByIdQueryResult>
    {
        public int Id { get; set; }

        public GetOrderDetailByIdQuery(int id)
        {
            Id = id;
        }
    }
}
