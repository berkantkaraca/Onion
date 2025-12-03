using Onion.Contract.RepositoryInterfaces;
using Onion.Domain.Entities;
using Onion.Persistence.ContextClasses;

namespace Onion.Persistence.RepositoryConcretes
{
    public class AppUserProfileRepository(MyContext context) : BaseRepository<AppUserProfile>(context), IAppUserProfileRepository
    {
    }
}