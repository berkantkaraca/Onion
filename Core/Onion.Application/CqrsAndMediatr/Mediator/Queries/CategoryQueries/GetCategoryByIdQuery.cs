using MediatR;
using Onion.Application.CqrsAndMediatr.Mediator.Results.CategoryResults;

namespace Onion.Application.CqrsAndMediatr.Mediator.Queries.CategoryQueries
{
    public class GetCategoryByIdQuery : IRequest<GetCategoryByIdQueryResult>
    {
        public int Id { get; set; }

        public GetCategoryByIdQuery(int id)
        {
            Id = id;
        }
    }
}
