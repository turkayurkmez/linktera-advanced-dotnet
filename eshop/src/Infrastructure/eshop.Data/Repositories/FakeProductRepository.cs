using eshop.Entities;

namespace eshop.Data.Repositories
{
    public class FakeProductRepository : IProductRepositoryAsync
    {
        private List<Product> _products;
        public FakeProductRepository()
        {
            _products = new List<Product> {
                new Product { Id = 2, Name="Product A", Price=100},
                new Product { Id = 1, Name="Product B", Price=100},
                new Product { Id = 3, Name="Product C", Price=100},


            };
        }
        public Task CreateAsync(Product entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IList<Product>> GetAllAsync()
        {
            return await Task.FromResult(_products);
        }

        public Task<Product> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Product>> SearchByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Product entity)
        {
            throw new NotImplementedException();
        }
    }
}
