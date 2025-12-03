using AutoMapper;
using Onion.Application.DtoClasses;
using Onion.Application.ManagerInterfaces;
using Onion.Contract.RepositoryInterfaces;
using Onion.Domain.Entities;

namespace Onion.InnerInfrastructure.ManagerConcretes
{
    public class CategoryManager(ICategoryRepository repository, IMapper mapper) : BaseManager<CategoryDto, Category>(repository, mapper), ICategoryManager
    {
        private readonly ICategoryRepository _repository = repository;
    }
}