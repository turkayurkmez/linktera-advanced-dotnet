using eshop.Data.Context;
using eshop.Entities;
using Microsoft.EntityFrameworkCore;

namespace eshop.Data.Repositories
{
    public class EFCategoryRepository : ICategoryRepository
    {
        private readonly EshopDbContext eshopDbContext;

        public EFCategoryRepository(EshopDbContext eshopDbContext)
        {
            this.eshopDbContext = eshopDbContext;
        }

        public Task CreateAsync(Category entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IList<Category>> GetAllAsync()
        {
            return await eshopDbContext.Categories.ToListAsync();
        }

        public Task<Category> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Category entity)
        {
            throw new NotImplementedException();
        }
    }
}
