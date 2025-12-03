using Onion.Contract.RepositoryInterfaces;
using Onion.Domain.Entities;
using Onion.Persistence.ContextClasses;

namespace Onion.Persistence.RepositoryConcretes
{
    public class OrderRepository(MyContext context) : BaseRepository<Order>(context), IOrderRepository
    {

    }
}
