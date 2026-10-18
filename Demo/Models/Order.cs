using System.ComponentModel.DataAnnotations;

namespace Demo.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        [Required]
        public DateTime OrderDate { get; set; }

        [Required]
        public string Status { get; set; }
        [Required]
        public decimal TotalAmount { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    }
}
