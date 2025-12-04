using MediatR;
using Onion.Application.CqrsAndMediatr.Mediator.Queries.OrderDetailQueries;
using Onion.Application.CqrsAndMediatr.Mediator.Results.OrderDetailResults;
using Onion.Contract.RepositoryInterfaces;
using Onion.Domain.Entities;

namespace Onion.Application.CqrsAndMediatr.Mediator.Handlers.Read.OrderDetailHandlers
{
    public class GetOrderDetailByIdQueryHandler : IRequestHandler<GetOrderDetailByIdQuery, GetOrderDetailByIdQueryResult>
    {
        private readonly IOrderDetailRepository _repository;

        public GetOrderDetailByIdQueryHandler(IOrderDetailRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetOrderDetailByIdQueryResult> Handle(GetOrderDetailByIdQuery request, CancellationToken cancellationToken)
        {
            OrderDetail value = await _repository.GetByIdAsync(request.Id);
            return new GetOrderDetailByIdQueryResult
            {
                Id = value.Id,
                OrderId = value.OrderId,
                ProductId = value.ProductId
            };
        }
    }
}
