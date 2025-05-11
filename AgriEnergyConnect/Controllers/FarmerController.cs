using AgriEnergyConnect.Data;
using AgriEnergyConnect.Models;
using Microsoft.AspNetCore.Mvc;
using BCrypt.Net;

namespace AgriEnergyConnect.Controllers
{
    [ApiController] // This tells ASP.NET that this is an API controller
    [Route("api/[controller]")]
    public class FarmerController : ControllerBase
    {
        private readonly AppDbContext _context;

        public FarmerController(AppDbContext context)
        {
            _context = context;
        }

        // Farmer registration
        [HttpPost("register")]
        public IActionResult Register(Farmer farmer)
        {
            // Hash the password
            farmer.Password = BCrypt.Net.BCrypt.HashPassword(farmer.Password);

            // Save the farmer in the database
            _context.Farmers.Add(farmer);
            _context.SaveChanges();

            return Ok("Farmer registered successfully.");
        }

        // Farmer login
        [HttpPost("login")]
        public IActionResult Login(string email, string password)
        {
            var farmer = _context.Farmers.FirstOrDefault(f => f.Email == email);
            if (farmer == null || !BCrypt.Net.BCrypt.Verify(password, farmer.Password))
            {
                return Unauthorized("Invalid credentials.");
            }

            return Ok("Login successful.");
        }
    }
}
