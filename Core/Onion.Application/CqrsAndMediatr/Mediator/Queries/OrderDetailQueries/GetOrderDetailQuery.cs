using MediatR;
using Onion.Application.CqrsAndMediatr.Mediator.Results.OrderDetailResults;

namespace Onion.Application.CqrsAndMediatr.Mediator.Queries.OrderDetailQueries
{
    public class GetOrderDetailQuery : IRequest<List<GetOrderDetailQueryResult>>
    {

    }
}
