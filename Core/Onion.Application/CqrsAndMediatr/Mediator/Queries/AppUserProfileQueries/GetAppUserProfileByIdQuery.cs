using MediatR;
using Onion.Application.CqrsAndMediatr.Mediator.Results.AppUserProfileResults;

namespace Onion.Application.CqrsAndMediatr.Mediator.Queries.AppUserProfileQueries
{
    public class GetAppUserProfileByIdQuery : IRequest<GetAppUserProfileByIdQueryResult>
    {
        public int Id { get; set; }

        public GetAppUserProfileByIdQuery(int id)
        {
            Id = id;
        }
    }
}
