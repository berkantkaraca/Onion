using AutoMapper;
using Onion.Application.DtoClasses;
using Onion.Application.ManagerInterfaces;
using Onion.Contract.RepositoryInterfaces;
using Onion.Domain.Entities;

namespace Onion.InnerInfrastructure.ManagerConcretes
{
    public class OrderDetailManager(IOrderDetailRepository repository, IMapper mapper) : BaseManager<OrderDetailDto, OrderDetail>(repository, mapper), IOrderDetailManager
    {
        private readonly IOrderDetailRepository _repository = repository;
    }
}
