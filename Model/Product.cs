namespace Final_project.Model
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal Price { get; set; }

        public string Productimg { get; set; } = null!;

        // Foreign key to Category
        public int CategoryId { get; set; }
        public Category? Category { get; set; } 
    }
}
