using eshop.DataTransferObjects.Requests;
using eshop.DataTransferObjects.Responses;

namespace eshop.Application
{
    public interface IProductService
    {
        //Uygulamanızın Product nesnesi ile gerçekleştirdiği her işlev bu yapının bir FONKSİYONUDUR!
        //............................................................................Objesidir.

        Task CreateNewAsync(CreateNewProductRequest request);
        //Task<Product> GetByIdAsync(int id);
        //Task RateProductAsync(Product product, byte newRate, int customerId);

        Task<IEnumerable<ProductCardResponse>> GetAllAsync();

    }
}
