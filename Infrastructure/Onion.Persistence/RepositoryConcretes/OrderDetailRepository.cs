using Onion.Contract.RepositoryInterfaces;
using Onion.Domain.Entities;
using Onion.Persistence.ContextClasses;

namespace Onion.Persistence.RepositoryConcretes
{
    public class OrderDetailRepository(MyContext context) : BaseRepository<OrderDetail>(context), IOrderDetailRepository
    {

    }
}
