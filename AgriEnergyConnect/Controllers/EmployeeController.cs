
using Microsoft.AspNetCore.Mvc;
using AgriEnergyConnect.Models;
using AgriEnergyConnect.Data;
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

        // GET: /Employee
        public IActionResult Index()
        {
            var employees = _context.Employees.ToList();
            return View(employees);
        }
        public IActionResult Dashboard()
        {
            return View();
        }
        // GET: /Employee/Create
        public IActionResult Create()
        {
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }
                public IActionResult Login()
        {
            return View();
        }
        // POST: /Employee/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                employee.Password = BCrypt.Net.BCrypt.HashPassword(employee.Password);
                _context.Employees.Add(employee);
                _context.SaveChanges();
                TempData["SuccessMessage"] = "Employee created successfully!";
                return RedirectToAction(nameof(Index));
            }

            TempData["ErrorMessage"] = "Failed to create employee.";
            return View(employee);
        }

        // GET: /Employee/Edit/5
        public IActionResult Edit(int id)
        {
            var employee = _context.Employees.Find(id);
            if (employee == null)
                return NotFound();

            var viewModel = new EmployeeEditViewModel
    {
        Id = employee.Id,
        FullName = employee.FullName,
        Username = employee.Username
    };

    return View(viewModel);
        }

        // POST: /Employee/Edit/5
[HttpPost]
[ValidateAntiForgeryToken]
public IActionResult Edit(EmployeeEditViewModel model)
{
    if (ModelState.IsValid)
    {
        var existing = _context.Employees.Find(model.Id);
        if (existing == null)
            return NotFound();

        existing.FullName = model.FullName;
        existing.Username = model.Username;

        _context.SaveChanges();
        TempData["SuccessMessage"] = "Employee updated successfully!";
        return RedirectToAction(nameof(Index));
    }

    TempData["ErrorMessage"] = "Failed to update employee.";
    return View(model);
}

        // GET: /Employee/Delete/5
        public IActionResult Delete(int id)
        {
            var employee = _context.Employees.Find(id);
            if (employee == null)
                return NotFound();

            return View(employee);
        }

        // POST: /Employee/DeleteConfirmed/5
        [HttpPost, ActionName("DeleteConfirmed")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var employee = _context.Employees.Find(id);
            if (employee == null)
                return NotFound();

            _context.Employees.Remove(employee);
            _context.SaveChanges();
            TempData["SuccessMessage"] = "Employee deleted successfully!";
            return RedirectToAction(nameof(Index));
        }
    }
}
