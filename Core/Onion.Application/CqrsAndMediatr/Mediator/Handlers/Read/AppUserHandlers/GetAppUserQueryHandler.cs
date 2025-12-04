using MediatR;
using Onion.Application.CqrsAndMediatr.Mediator.Queries.AppUserQueries;
using Onion.Application.CqrsAndMediatr.Mediator.Results.AppUserResults;
using Onion.Contract.RepositoryInterfaces;
using Onion.Domain.Entities;

namespace Onion.Application.CqrsAndMediatr.Mediator.Handlers.Read.AppUserHandlers
{
    public class GetAppUserQueryHandler : IRequestHandler<GetAppUserQuery, List<GetAppUserQueryResult>>
    {
        private readonly IAppUserRepository _repository;

        public GetAppUserQueryHandler(IAppUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetAppUserQueryResult>> Handle(GetAppUserQuery request, CancellationToken cancellationToken)
        {
            List<AppUser> values = await _repository.GetAllAsync();
            return values.Select(x => new GetAppUserQueryResult
            {
                Id = x.Id,
                Password = x.Password,
                UserName = x.UserName
            }).ToList();
        }
    }
}
