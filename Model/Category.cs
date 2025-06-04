namespace Final_project.Model
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        // One Category has many Products
        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
