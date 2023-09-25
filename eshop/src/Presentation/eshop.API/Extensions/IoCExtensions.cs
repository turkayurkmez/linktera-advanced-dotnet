using eshop.Application.Handlers;
using eshop.Application.Mappings;
using eshop.Data.Context;
using eshop.Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace eshop.API.Extensions
{
    public static class IoCExtensions
    {
        public static IServiceCollection AddInjectionsToIoC(this IServiceCollection services, string connectionString)
        {
            services.AddAutoMapper(typeof(MapProfile));

            services.AddScoped<IProductRepositoryAsync, EFProductRepository>();
            services.AddScoped<ICategoryRepository, EFCategoryRepository>();

            services.AddMediatR(config => config.RegisterServicesFromAssembly(typeof(GetAllProductRequestHandler).Assembly));

            services.AddDbContext<EshopDbContext>(options => options.UseSqlServer(connectionString));

            return services;
        }
    }
}
