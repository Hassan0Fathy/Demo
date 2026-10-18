using System.ComponentModel.DataAnnotations;

namespace Demo.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        [Required, StringLength(maximumLength:100 , MinimumLength =3)]
        public string FullName { get; set; }
        [Required , EmailAddress]
        public string Email { get; set; }
        [Required]
        public string PasswordHash { get; set; }
        [Required]
        public string Role { get; set; }
        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
