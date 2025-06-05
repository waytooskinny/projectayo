using System.ComponentModel.DataAnnotations;

namespace Final_project.Dto_s
{
    public class Logindto
    {
        [Required]
        public string Email { get; set; } = null!;
        [Required]
        [MinLength(8, ErrorMessage = "Password must be 8 characters long")]
        public string Password { get; set; } = null!;

    }
}
