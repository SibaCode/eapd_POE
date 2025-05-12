using Microsoft.AspNetCore.Mvc;
using AgriEnergyConnect.Models;
using AgriEnergyConnect.Data;
using AgriEnergyConnect.Services;
using Microsoft.AspNetCore.Http;
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

        // GET: /Employee/Login
        [HttpGet]
        public IActionResult Login()
        {
            return View(new LoginViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var employee = _context.Employees.FirstOrDefault(e => e.Username == model.Username);

                if (employee != null && BCrypt.Net.BCrypt.Verify(model.Password, employee.PasswordHash))
                {
                    // Store the username in the session or claims
                    HttpContext.Session.SetString("Username", employee.Username);

                    // Optionally, you can store the employee ID or other info
                    HttpContext.Session.SetString("FullName", employee.FullName);

                    // Redirect to the Dashboard
                    return RedirectToAction("Dashboard", "Employee");
                } else{
                ModelState.AddModelError(string.Empty, "Invalid username or password.");


                }

            }

            return View(model); // Return the view with error if credentials are invalid
        }


        // GET: /Employee/Register
        [HttpGet]
        public IActionResult Register()
        {
            return View(new Employee());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(Employee employee)
        {
            if (ModelState.IsValid)
            {
                if (_context.Employees.Any(e => e.Username == employee.Username))
                {
                    ModelState.AddModelError("Username", "Username already exists.");
                    return View(employee);
                }

                employee.PasswordHash = BCrypt.Net.BCrypt.HashPassword(employee.PasswordHash);
                _context.Employees.Add(employee);
                _context.SaveChanges();

                TempData["SuccessMessage"] = "Registration successful! Please log in.";
                return RedirectToAction("Login");
            }

            return View(employee);
        }

      [HttpGet]
public IActionResult Dashboard(string categoryFilter = null, bool? inStockFilter = null)
{
    var username = HttpContext.Session.GetString("Username");
    var fullName = HttpContext.Session.GetString("FullName");

    if (string.IsNullOrEmpty(username))
        return RedirectToAction("Login", "Employee");

    var employee = _context.Employees.FirstOrDefault(e => e.Username == username);
    if (employee == null)
        return RedirectToAction("Login", "Employee");

    // Filter products
    var productsQuery = _context.Products.AsQueryable();

    if (!string.IsNullOrEmpty(categoryFilter))
        productsQuery = productsQuery.Where(p => p.Category == categoryFilter);

    if (inStockFilter.HasValue)
        productsQuery = productsQuery.Where(p => p.InStock == inStockFilter.Value);

    var dashboardData = new DashboardViewModel
    {
        TotalFarmers = _context.Farmers.Count(),
        TotalProducts = _context.Products.Count(),
        LoggedInEmployeeName = fullName ?? employee.FullName,
        CategoryFilter = categoryFilter,
        InStockFilter = inStockFilter,
        FilteredProducts = productsQuery.ToList()
    };

    return View(dashboardData);
}




        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}
