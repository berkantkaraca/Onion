using AutoMapper;
using Onion.Application.DtoClasses;
using Onion.Application.ManagerInterfaces;
using Onion.Contract.RepositoryInterfaces;
using Onion.Domain.Entities;

namespace Onion.InnerInfrastructure.ManagerConcretes
{
    public class AppUserProfileManager(IAppUserProfileRepository repository, IMapper mapper) : BaseManager<AppUserProfileDto, AppUserProfile>(repository, mapper), IAppUserProfileManager
    {
        private readonly IAppUserProfileRepository _repository = repository;
    }
}
