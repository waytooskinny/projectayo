namespace Final_project.Model
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime Orderdate { get; set; } = DateTime.Now;
        public string Customername { get; set; } = null!;
        public string Customeremail { get; set; } = null!;

         public int CustomerId {  get; set; }
        public Customer Customer { get; set; } = null!;
        // One Order has many OrderItems
        public ICollection<OrderItem> Orderdetail { get; set; } = new List<OrderItem>();
    }
}
