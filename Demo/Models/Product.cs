using System.ComponentModel.DataAnnotations;

namespace Demo.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        [Required, StringLength(maximumLength:100,MinimumLength =2)]
        public string ProductName { get; set; }
        [StringLength(maximumLength:50)]
        public string? Description { get; set; }
        [Required, Range(0.01 ,1000000.00)]
        public decimal Price { get; set; }
        [Required, Range(0, 1000000)]

        public int StockQuantity { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}
