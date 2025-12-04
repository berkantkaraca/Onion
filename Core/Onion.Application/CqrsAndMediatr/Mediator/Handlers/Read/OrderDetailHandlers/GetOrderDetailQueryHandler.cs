using MediatR;
using Onion.Application.CqrsAndMediatr.Mediator.Queries.OrderDetailQueries;
using Onion.Application.CqrsAndMediatr.Mediator.Results.OrderDetailResults;
using Onion.Contract.RepositoryInterfaces;
using Onion.Domain.Entities;

namespace Onion.Application.CqrsAndMediatr.Mediator.Handlers.Read.OrderDetailHandlers
{
    public class GetOrderDetailQueryHandler : IRequestHandler<GetOrderDetailQuery, List<GetOrderDetailQueryResult>>
    {
        private readonly IOrderDetailRepository _repository;

        public GetOrderDetailQueryHandler(IOrderDetailRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetOrderDetailQueryResult>> Handle(GetOrderDetailQuery request, CancellationToken cancellationToken)
        {
            List<OrderDetail> values = await _repository.GetAllAsync();
            return values.Select(x => new GetOrderDetailQueryResult
            {
                Id = x.Id,
                OrderId = x.OrderId,
                ProductId = x.ProductId
            }).ToList();
        }
    }
}
