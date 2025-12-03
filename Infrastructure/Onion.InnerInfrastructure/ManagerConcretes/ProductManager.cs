using AutoMapper;
using Onion.Application.DtoClasses;
using Onion.Application.ManagerInterfaces;
using Onion.Contract.RepositoryInterfaces;
using Onion.Domain.Entities;

namespace Onion.InnerInfrastructure.ManagerConcretes
{
    public class ProductManager(IProductRepository repository, IMapper mapper) : BaseManager<ProductDto, Product>(repository, mapper), IProductManager
    {
        private readonly IProductRepository _repository = repository;
    }
}
