using Final_project.Model;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Final_project.Data;
using Microsoft.AspNetCore.Identity;

namespace Final_project.Data
{
    public class Cofeecontext : DbContext
    {
        public Cofeecontext(DbContextOptions<Cofeecontext> options)
        : base(options)
        {
        }
        public DbSet<Category> Category { get; set; }
        public DbSet<Order> Order { get; set; }

        public DbSet<Comment> Comment { get; set; }
        public DbSet<OrderItem> OrderItem { get; set; }
        public DbSet<Customer> Customer { get; set; }  
        public  DbSet<Product> Product { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>();
                 modelBuilder.Entity<Product>()
                     .Property(p => p.Price)
                     .HasPrecision(6, 2);
           
           base.OnModelCreating(modelBuilder); 
        }





    }
}
