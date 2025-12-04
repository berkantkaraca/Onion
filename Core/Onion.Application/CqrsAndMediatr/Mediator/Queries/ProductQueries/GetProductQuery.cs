using MediatR;
using Onion.Application.CqrsAndMediatr.Mediator.Results.ProductResults;

namespace Onion.Application.CqrsAndMediatr.Mediator.Queries.ProductQueries
{
    public class GetProductQuery : IRequest<List<GetProductQueryResult>>
    {

    }
}
