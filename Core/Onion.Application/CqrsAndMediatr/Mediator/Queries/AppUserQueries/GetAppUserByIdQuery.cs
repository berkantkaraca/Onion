using MediatR;

namespace Onion.Application.CqrsAndMediatr.Mediator.Queries.AppUserQueries
{
    public class GetAppUserByIdQuery : IRequest<GetAppUserByIdQuery>
    {
        public int Id { get; set; }

        public GetAppUserByIdQuery(int id)
        {
            Id = id;
        }
    }
}
