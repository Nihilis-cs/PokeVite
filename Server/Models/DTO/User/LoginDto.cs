using System.ComponentModel.DataAnnotations;

namespace server.Controllers
{
    public class LoginDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Password { get; set; }
    }
}