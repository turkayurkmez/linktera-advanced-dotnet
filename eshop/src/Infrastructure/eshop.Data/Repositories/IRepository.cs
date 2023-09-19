using eshop.Entities;

namespace eshop.Data.Repositories
{
    public interface IRepositoryAsync<T> where T : class, IEntity, new()
    {
        Task<T> GetByIdAsync(int id);
        Task<IList<T>> GetAllAsync();
        Task CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(int id);


    }
}
