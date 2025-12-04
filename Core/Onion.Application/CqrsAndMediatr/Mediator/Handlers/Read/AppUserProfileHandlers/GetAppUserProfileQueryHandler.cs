using MediatR;
using Onion.Application.CqrsAndMediatr.Mediator.Queries.AppUserProfileQueries;
using Onion.Application.CqrsAndMediatr.Mediator.Results.AppUserProfileResults;
using Onion.Contract.RepositoryInterfaces;
using Onion.Domain.Entities;

namespace Onion.Application.CqrsAndMediatr.Mediator.Handlers.Read.AppUserProfileHandlers
{
    public class GetAppUserProfileQueryHandler : IRequestHandler<GetAppUserProfileQuery, List<GetAppUserProfileQueryResult>>
    {
        private readonly IAppUserProfileRepository _repository;

        public GetAppUserProfileQueryHandler(IAppUserProfileRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetAppUserProfileQueryResult>> Handle(GetAppUserProfileQuery request, CancellationToken cancellationToken)
        {
            List<AppUserProfile> values = await _repository.GetAllAsync();
            return values.Select(x => new GetAppUserProfileQueryResult
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                AppUserId = x.AppUserId
            }).ToList();
        }
    }
}
