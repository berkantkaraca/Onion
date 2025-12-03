using AutoMapper;
using Onion.Application.DtoClasses;
using Onion.Application.ManagerInterfaces;
using Onion.Contract.RepositoryInterfaces;
using Onion.Domain.Entities;

namespace Onion.InnerInfrastructure.ManagerConcretes
{
    public class OrderManager(IOrderRepository repository, IMapper mapper) : BaseManager<OrderDto, Order>(repository, mapper), IOrderManager
    {
        private readonly IOrderRepository _repository = repository;
    }
}
