using Azure.Identity;
using BCrypt;
using Final_project.Data;
using Final_project.Dto_s;
using Final_project.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;


namespace Final_project.Controllers
{

    [ApiController]
    [Route("api/[controller]")]

    public class AuthController : ControllerBase
    {
        private readonly Cofeecontext _context;

        public AuthController(Cofeecontext context)
        {
            _context = context;
        }

        [HttpGet("Id")]
        public IActionResult Getregistered(int id)
        {
            var locatecustomers = _context.Customer.FirstOrDefault(c => c.Id == id);
            return Ok(locatecustomers);
        }

        [HttpPost("register")]
        public IActionResult Signupcustomer(Registerdto registerdto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            // if mail already exsist

            var exsistingcustomer = _context.Customer.FirstOrDefault(c => c.Email == registerdto.Email);
            if (exsistingcustomer != null)
            {
                return BadRequest("Email already exsist");
            }
            
            //creating a customer sign up
            var customer = new Customer
            {
                Name = registerdto.Name,
                Email = registerdto.Email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(registerdto.Password)
            };
            _context.Customer.Add(customer);
            _context.SaveChanges();

            return Ok("Signup successful.");
        }
        [HttpPost("Login")]
        public IActionResult Login(Logindto logindto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            //find customer by mail
            var customer = _context.Customer.FirstOrDefault(c => c.Email == logindto.Email);
            if( customer == null)
            {
                return BadRequest("Not available");
            }
            //verify the password is correct using Bycrpt thing
            bool isPasswordcorrect = BCrypt.Net.BCrypt.Verify(logindto.Password, customer.PasswordHash);
            if (!isPasswordcorrect)
            {
                return Unauthorized("Customer does not exsist");
            }

            return Ok("Login SUCCESSFUL");
        }
    }
    }
 