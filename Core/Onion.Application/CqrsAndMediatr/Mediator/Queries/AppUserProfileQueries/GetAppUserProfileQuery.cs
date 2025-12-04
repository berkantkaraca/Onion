using MediatR;
using Onion.Application.CqrsAndMediatr.Mediator.Results.AppUserProfileResults;

namespace Onion.Application.CqrsAndMediatr.Mediator.Queries.AppUserProfileQueries
{
    public class GetAppUserProfileQuery : IRequest<List<GetAppUserProfileQueryResult>>
    {

    }
}
