using Microsoft.AspNetCore.Mvc;
using Final_project.Data;
using Final_project.Model;
using System.Linq;

namespace Final_project.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderItemController : ControllerBase
    {
        private readonly Cofeecontext _context;

        public OrderItemController(Cofeecontext context)
        {
            _context = context;
        }

 
        [HttpGet]
        public IActionResult GetAllOrderItems()
        {
            var items = _context.OrderItem.ToList();
            return Ok(items);
        }

        // GET: api/orderitem/order/5
        [HttpGet("order/{orderId}")]
        public IActionResult GetItemsByOrder(int orderId)
        {
            var items = _context.OrderItem.Where(i => i.OrderId == orderId).ToList();
            return Ok(items);
        }

        // POST: api/orderitem
        [HttpPost]
        public IActionResult AddOrderItem(OrderItem item)
        {
            var productExists = _context.Product.Any(p => p.Id == item.ProductId);
            var orderExists = _context.Order.Any(o => o.Id == item.OrderId);

            if (!productExists || !orderExists)
            {
                return BadRequest("Invalid ProductId or OrderId.");
            }

            _context.OrderItem.Add(item);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetAllOrderItems), new { id = item.Id }, item);
        }


         
        [HttpDelete("{id}")]
        public IActionResult DeleteOrderItem(int id)
        {
            var item = _context.OrderItem.FirstOrDefault(i => i.Id == id);
            if (item == null)
                return NotFound();

            _context.OrderItem.Remove(item);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
