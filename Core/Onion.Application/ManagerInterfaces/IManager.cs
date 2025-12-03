using Onion.Application.DtoInterfaces;
using Onion.Domain.Interfaces;

namespace Onion.Application.ManagerInterfaces
{
    public interface IManager<T, U> where T : class, IDto where U : class, IEntity // T: Dto Sınıfı (UI'a erişen), U: Entity Sınıfı.
    {
        //BL for Queries
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        List<T> GetActives();
        List<T> GetPassives();
        List<T> GetUpdateds();

        //BL for Commands
        Task CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task<string> SoftDeleteAsync(int id);
        Task<string> HardDeleteAsync(int id);
    }
}
