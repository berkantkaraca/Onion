using Onion.Contract.RepositoryInterfaces;
using Onion.Domain.Entities;
using Onion.Persistence.ContextClasses;

namespace Onion.Persistence.RepositoryConcretes
{
    public class ProductRepository(MyContext context) : BaseRepository<Product>(context), IProductRepository
    {

    }
}
