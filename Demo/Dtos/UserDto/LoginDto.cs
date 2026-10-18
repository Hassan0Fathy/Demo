using System.ComponentModel.DataAnnotations;

namespace Demo.Dtos
{
    public class LoginDto
    {
        public string Email { get; set; }
        public string PasswordHash { get; set; }
    }
}
