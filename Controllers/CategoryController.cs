using Final_project.Data;
using Final_project.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
namespace Final_project.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
        
        public class CategoryController : ControllerBase
        {
            private readonly Cofeecontext _context;

            public CategoryController(Cofeecontext context)
            {
                _context = context;
            }

            [HttpGet]
            public IActionResult Getall(int Id)
            {

                var category = _context.Category.ToList();
                return Ok(category);


            }

            [HttpGet("{Id}")]
            public IActionResult Getintby(int id)
            {
                var category = _context.Category.FirstOrDefault();
                if (category == null)
                {
                    return NotFound();
                }
                return Ok(category);

            }

            [HttpPost]
            public IActionResult AddCategory(Category category)
            {
               _context.Category.Add(category);
                _context.SaveChanges();

                return CreatedAtAction(nameof(Getintby), new { id = category.Id }, category);


            }
          
            [HttpDelete("{id}")]
            public IActionResult Delete(int id)
            {
                var category = _context.Category.FirstOrDefault(c => c.Id == id);

                if (category == null)
                {
                    return NotFound();
                } 
                _context.Category.Remove(category);
                _context.SaveChanges();

                return NoContent();
            }
            [HttpPut("{id}")]
            public IActionResult Updatecategory(int id, Category updatedcategory)
            {
                var category = _context.Category.FirstOrDefault(c =>c.Id == id);
                if (category == null)
                    return NoContent();
                category.Name = updatedcategory.Name;
                _context.SaveChanges();

                return NoContent();

            }

        }
    }
