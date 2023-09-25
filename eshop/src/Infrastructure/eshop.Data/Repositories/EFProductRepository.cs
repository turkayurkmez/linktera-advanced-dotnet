using eshop.Data.Context;
using eshop.Entities;
using Microsoft.EntityFrameworkCore;

namespace eshop.Data.Repositories
{
    public class EFProductRepository : IProductRepositoryAsync
    {

        private readonly EshopDbContext _dbContext;

        public EFProductRepository(EshopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateAsync(Product entity)
        {
            await _dbContext.Products.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var product = await _dbContext.Products.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);
            _dbContext.Products.Remove(product);
            await _dbContext.SaveChangesAsync();

        }

        public async Task<IList<Product>> GetAllAsync()
        {
            return await _dbContext.Products.Include(p => p.Category).ToListAsync();
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            return await _dbContext.Products.FindAsync(id);
        }

        public async Task<IEnumerable<Product>> SearchByNameAsync(string name)
        {
            return await _dbContext.Products.Where(p => p.Name.Contains(name, StringComparison.CurrentCultureIgnoreCase)).ToListAsync();
        }

        public async Task UpdateAsync(Product entity)
        {
            _dbContext.Products.Update(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
