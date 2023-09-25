using eshop.DataTransferObjects.Responses;

namespace eshop.MVC.Models
{
    public class ProductsViewModel
    {
        public IEnumerable<ProductCardResponse> Products { get; set; }
        public PageModel PageModel { get; set; }
    }
}
