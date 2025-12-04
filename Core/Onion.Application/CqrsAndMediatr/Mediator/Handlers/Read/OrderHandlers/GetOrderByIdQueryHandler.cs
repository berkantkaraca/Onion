using MediatR;
using Onion.Application.CqrsAndMediatr.Mediator.Queries.OrderQueries;
using Onion.Application.CqrsAndMediatr.Mediator.Results.OrderResults;
using Onion.Contract.RepositoryInterfaces;
using Onion.Domain.Entities;

namespace Onion.Application.CqrsAndMediatr.Mediator.Handlers.Read.OrderHandlers
{
    public class GetOrderByIdQueryHandler : IRequestHandler<GetOrderByIdQuery, GetOrderByIdQueryResult>
    {
        private readonly IOrderRepository _repository;

        public GetOrderByIdQueryHandler(IOrderRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetOrderByIdQueryResult> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
            Order value = await _repository.GetByIdAsync(request.Id);
            return new GetOrderByIdQueryResult
            {
                Id = value.Id,
                ShippingAddress = value.ShippingAddress,
                AppUserId = value.AppUserId
            };
        }
    }
}
