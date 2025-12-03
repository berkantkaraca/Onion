using Onion.Contract.RepositoryInterfaces;
using Onion.Domain.Entities;
using Onion.Persistence.ContextClasses;

namespace Onion.Persistence.RepositoryConcretes
{
    public class CategoryRepository(MyContext context) : BaseRepository<Category>(context), ICategoryRepository
    {

    }
}
