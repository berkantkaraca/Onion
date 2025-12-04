using MediatR;
using Onion.Application.CqrsAndMediatr.Mediator.Queries.AppUserQueries;
using Onion.Application.CqrsAndMediatr.Mediator.Results.AppUserResults;
using Onion.Contract.RepositoryInterfaces;
using Onion.Domain.Entities;

namespace Onion.Application.CqrsAndMediatr.Mediator.Handlers.Read.AppUserHandlers
{
    public class GetAppUserByIdQueryHandler : IRequestHandler<GetAppUserByIdQuery, GetAppUserByIdQueryResult>
    {
        private readonly IAppUserRepository _repository;

        public GetAppUserByIdQueryHandler(IAppUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetAppUserByIdQueryResult> Handle(GetAppUserByIdQuery request, CancellationToken cancellationToken)
        {
            AppUser value = await _repository.GetByIdAsync(request.Id);

            return new GetAppUserByIdQueryResult
            {
                Id = value.Id,
                Password = value.Password,
                UserName = value.UserName
            };
        }
    }
}
