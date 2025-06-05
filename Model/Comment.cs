using System.ComponentModel.DataAnnotations;

namespace Final_project.Model
{
    public class Comment
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = null!;
        [Required]
        
       public string Email { get; set; } = null!;
        [Required]
        public string Message { get; set; } = null!;

    }
}
