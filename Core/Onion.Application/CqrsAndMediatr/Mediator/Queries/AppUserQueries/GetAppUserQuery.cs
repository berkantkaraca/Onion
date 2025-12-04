using MediatR;
using Onion.Application.CqrsAndMediatr.Mediator.Results.AppUserResults;

namespace Onion.Application.CqrsAndMediatr.Mediator.Queries.AppUserQueries
{
    //IRequest isteğin ne türden döneceğini bildirir
    public class GetAppUserQuery : IRequest<List<GetAppUserQueryResult>>   
    {

    }
}
