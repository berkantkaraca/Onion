using MediatR;
using Onion.Application.CqrsAndMediatr.Mediator.Queries.AppUserProfileQueries;
using Onion.Application.CqrsAndMediatr.Mediator.Results.AppUserProfileResults;
using Onion.Contract.RepositoryInterfaces;
using Onion.Domain.Entities;

namespace Onion.Application.CqrsAndMediatr.Mediator.Handlers.Read.AppUserProfileHandlers
{
    public class GetAppUserProfileByIdQueryHandler : IRequestHandler<GetAppUserProfileByIdQuery, GetAppUserProfileByIdQueryResult>
    {
        private readonly IAppUserProfileRepository _repository;

        public GetAppUserProfileByIdQueryHandler(IAppUserProfileRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetAppUserProfileByIdQueryResult> Handle(GetAppUserProfileByIdQuery request, CancellationToken cancellationToken)
        {
            AppUserProfile value = await _repository.GetByIdAsync(request.Id);
            return new GetAppUserProfileByIdQueryResult
            {
                Id = value.Id,
                FirstName = value.FirstName,
                LastName = value.LastName,
                AppUserId = value.AppUserId
            };
        }
    }
}
