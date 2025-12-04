using Onion.Domain.Interfaces;
using System.Linq.Expressions;

namespace Onion.Contract.RepositoryInterfaces
{
    public interface IRepository<T>  where T : class , IEntity
    {
        //Queries
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        IQueryable<T> Where(Expression<Func<T, bool>> exp);

        //Commands
        Task CreateAsync(T entity);
        Task UpdateAsync(T oldEntity, T newEntity);
        Task DeleteAsync(T entity);
        Task<int> SaveChangesAsync();
    }
}
