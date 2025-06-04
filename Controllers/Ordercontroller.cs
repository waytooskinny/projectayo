using Microsoft.AspNetCore.Mvc;
using Final_project.Data;
using Final_project.Model;
using System.Linq;

namespace Final_project.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly Cofeecontext _context;

        public OrderController(Cofeecontext context)
        {
            _context = context;
        }

         
        [HttpGet]
        public IActionResult GetAllOrders()
        {
            var orders = _context.Order.ToList();
            return Ok(orders);
        }

         
        [HttpGet("{id}")]
        public IActionResult GetOrder(int id)
        {
            var order = _context.Order.FirstOrDefault(o => o.Id == id);
            if (order == null)
                return NotFound();

            return Ok(order);
        }

         
        [HttpPost]
        public IActionResult CreateOrder(Order order)
        {
            order.Orderdate = DateTime.Now;
            _context.Order.Add(order);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetOrder), new { id = order.Id }, order);
        }

         
        [HttpPut("{id}")]
        public IActionResult UpdateOrder(int id, Order updatedOrder)
        {
            var order = _context.Order.FirstOrDefault(o => o.Id == id);
            if (order == null)
                return NotFound();

            order.Customername = updatedOrder.Customername;
            order.Customeremail = updatedOrder.Customeremail;
            order.Orderdate = updatedOrder.Orderdate;

            _context.SaveChanges();

            return NoContent();
        }

         
        [HttpDelete("{id}")]
        public IActionResult DeleteOrder(int id)
        {
            var order = _context.Order.FirstOrDefault(o => o.Id == id);
            if (order == null)
                return NotFound();

            _context.Order.Remove(order);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
