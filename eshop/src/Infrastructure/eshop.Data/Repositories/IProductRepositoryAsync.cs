using eshop.Entities;

namespace eshop.Data.Repositories
{
    //CQRS tercih edilecekse; bu interface'e ihtiyaç olmaz.
    public interface IProductRepositoryAsync : IRepositoryAsync<Product>
    {
        Task<IEnumerable<Product>> SearchByNameAsync(string name);


    }
}
