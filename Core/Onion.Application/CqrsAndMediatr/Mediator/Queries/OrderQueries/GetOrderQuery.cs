using MediatR;
using Onion.Application.CqrsAndMediatr.Mediator.Results.OrderResults;

namespace Onion.Application.CqrsAndMediatr.Mediator.Queries.OrderQueries
{
    public class GetOrderQuery : IRequest<List<GetOrderQueryResult>>
    {

    }
}
