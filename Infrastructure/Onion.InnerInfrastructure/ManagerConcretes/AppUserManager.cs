using AutoMapper;
using Onion.Application.DtoClasses;
using Onion.Application.ManagerInterfaces;
using Onion.Contract.RepositoryInterfaces;
using Onion.Domain.Entities;

namespace Onion.InnerInfrastructure.ManagerConcretes
{
    public class AppUserManager(IAppUserRepository repository, IMapper mapper) : BaseManager<AppUserDto, AppUser>(repository, mapper), IAppUserManager
    {
        private readonly IAppUserRepository _repository = repository;
    }
}
