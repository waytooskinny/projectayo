using Final_project.Data;
using Final_project.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;




namespace Final_project.Controllers
{
   
        [ApiController]
        [Route("api/[controller]")]
        public class ProductsController : ControllerBase
        {
            private readonly Cofeecontext _context;

            public ProductsController(Cofeecontext context)
            {
                _context = context;
            }
            
            [HttpGet]
            public IActionResult Getproducts()
            {
                var product = _context.Product.ToList();
                    return Ok(product);
            }
            
            [HttpGet("{Id}")]
            public IActionResult GetproductsbyId(int id)
            {

                var product = _context.Product.FirstOrDefault(x => x.Id == id);
                if (product == null)
                {
                    return NotFound();
                }
                return Ok(product);
            }

            [HttpPost]
            public IActionResult Createproducts(Product product)
            {
                _context.Product.Add(product);
                _context.SaveChanges();

                return CreatedAtAction(nameof(GetproductsbyId), new { id = product.Id }, product);
            }
        
            [HttpDelete("{Id}")]
            public IActionResult Deleteproductsbyid(int id)
            {
                var product = _context.Product.FirstOrDefault(x => x.Id == id);
                if (product == null)
                {
                    return NotFound();
                }
                _context.Product.Remove(product);
                _context.SaveChanges();
                return NoContent();

            }
        [HttpPut("{id}")]
            public IActionResult Updateproductbyid(Product updated, int id)
            {
                var product = _context.Product.FirstOrDefault(p => p.Id == id);
                if (product == null)
                    return NotFound();

                product.Name = updated.Name;
                product.Description = updated.Description;
                product.Price = updated.Price;
                product.CategoryId = updated.CategoryId;

                _context.SaveChanges();
                return NoContent();


            }

    }
}
