using System.ComponentModel.DataAnnotations;

namespace Final_project.Model
{
    public class Customer
    {
         public int Id { get; set; }
     
        public string Name { get; set; } = null!;
        [Required]
        public string Email { get; set; } = null!;
        [Required]
        public string PasswordHash { get; set; } = null!;
        
        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
