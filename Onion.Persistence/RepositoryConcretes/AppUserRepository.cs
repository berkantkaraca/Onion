using Onion.Contract.RepositoryInterfaces;
using Onion.Domain.Entities;
using Onion.Persistence.ContextClasses;

namespace Onion.Persistence.RepositoryConcretes
{
    public class AppUserRepository(MyContext context) : BaseRepository<AppUser>(context), IAppUserRepository
    {
    }
}
