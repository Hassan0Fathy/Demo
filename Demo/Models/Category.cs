using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Demo.Models
{
    [Index(nameof(CategoryName), IsUnique =true)]
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        [Required, StringLength(maximumLength:100 , MinimumLength =2)]
        public string CategoryName { get; set; }
        [StringLength(maximumLength:200)]
        public string? Description { get; set; }
        public ICollection<Product> Products { get; set; } = new List<Product>();

    }
}
