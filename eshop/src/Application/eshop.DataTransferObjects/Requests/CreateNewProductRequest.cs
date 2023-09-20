using MediatR;
using System.ComponentModel.DataAnnotations;

namespace eshop.DataTransferObjects.Requests
{
    public class CreateNewProductRequest : IRequest<int>
    {
        [Required(ErrorMessage = "Ürün adı boş olmamalı")]
        [MinLength(3, ErrorMessage = "En az 3 karakter giriniz...")]
        public string Name { get; set; }
        public string? Description { get; set; }
        public decimal? Price { get; set; }
        public decimal? Discount { get; set; }
        public int? StockCount { get; set; }
    }
}
