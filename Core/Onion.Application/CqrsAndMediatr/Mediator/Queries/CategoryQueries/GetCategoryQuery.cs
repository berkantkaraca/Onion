using MediatR;
using Onion.Application.CqrsAndMediatr.Mediator.Results.CategoryResults;

namespace Onion.Application.CqrsAndMediatr.Mediator.Queries.CategoryQueries
{
    public class GetCategoryQuery : IRequest<List<GetCategoryQueryResult>>
    {

    }
}
