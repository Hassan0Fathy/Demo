using System.ComponentModel.DataAnnotations;

namespace Demo.Dtos.ProductDto
{
    public class CreateProductDto
    {
        public string ProductName { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public int CategoryId { get; set; }
    }
}
