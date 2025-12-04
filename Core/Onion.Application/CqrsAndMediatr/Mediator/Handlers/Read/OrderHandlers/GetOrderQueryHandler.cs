using MediatR;
using Onion.Application.CqrsAndMediatr.Mediator.Queries.OrderQueries;
using Onion.Application.CqrsAndMediatr.Mediator.Results.OrderResults;
using Onion.Contract.RepositoryInterfaces;
using Onion.Domain.Entities;

namespace Onion.Application.CqrsAndMediatr.Mediator.Handlers.Read.OrderHandlers
{
    public class GetOrderQueryHandler : IRequestHandler<GetOrderQuery, List<GetOrderQueryResult>>
    {
        private readonly IOrderRepository _repository;

        public GetOrderQueryHandler(IOrderRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetOrderQueryResult>> Handle(GetOrderQuery request, CancellationToken cancellationToken)
        {
            List<Order> values = await _repository.GetAllAsync();
            return values.Select(x => new GetOrderQueryResult
            {
                Id = x.Id,
                ShippingAddress = x.ShippingAddress,
                AppUserId = x.AppUserId
            }).ToList();
        }
    }
}
