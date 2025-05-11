using AgriEnergyConnect.Data;
using AgriEnergyConnect.Models;
using Microsoft.AspNetCore.Mvc;
using BCrypt.Net;

namespace AgriEnergyConnect.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly AppDbContext _context;

        public EmployeeController(AppDbContext context)
        {
            _context = context;
        }

        // Employee registration
        [HttpPost("employee/register")]
        public IActionResult Register(Employee employee)
        {
            // Hash the password
            employee.Password = BCrypt.Net.BCrypt.HashPassword(employee.Password);

            // Save the employee in the database
            _context.Employees.Add(employee);
            _context.SaveChanges();

            return Ok("Employee registered successfully.");
        }

        // Employee login
        [HttpPost("employee/login")]
        public IActionResult Login(string username, string password)
        {
            var employee = _context.Employees.FirstOrDefault(e => e.Username == username);
            if (employee == null || !BCrypt.Net.BCrypt.Verify(password, employee.Password))
            {
                return Unauthorized("Invalid credentials.");
            }

            return Ok("Login successful.");
        }
    }
}
