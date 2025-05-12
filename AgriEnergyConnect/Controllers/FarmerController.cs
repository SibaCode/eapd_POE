using Microsoft.AspNetCore.Mvc;
using AgriEnergyConnect.Data;
using AgriEnergyConnect.Models;
using Microsoft.AspNetCore.Identity;

using BCrypt.Net;

namespace AgriEnergyConnect.Controllers
{
    public class FarmerController : Controller
    {
        private readonly AppDbContext _context;


        public FarmerController(AppDbContext context)
        {
            _context = context;

        }

        [HttpGet]
        public IActionResult Login()
        {
            return View(new FarmerLoginViewModel());
        }
public IActionResult Index()
{
    var farmers = _context.Farmers.ToList();
    return View(farmers);
}
     [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(FarmerLoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var farmer = _context.Farmers.FirstOrDefault(f => f.Username == model.Username);
                if (farmer != null && BCrypt.Net.BCrypt.Verify(model.Password, farmer.PasswordHash))
                {
                    HttpContext.Session.SetString("FarmerUsername", farmer.Username);
                    return RedirectToAction("Dashboard", "Farmer");
                }

                ModelState.AddModelError("", "Invalid username or password.");
            }

            return View(model);
        }



       public IActionResult Dashboard()
{
    var farmerUsername = HttpContext.Session.GetString("FarmerUsername");
    if (string.IsNullOrEmpty(farmerUsername))
    {
        return RedirectToAction("Login");
    }

    var farmer = _context.Farmers.FirstOrDefault(f => f.Username == farmerUsername);
    if (farmer == null)
    {
        return RedirectToAction("Login");
    }

    var products = _context.Products
        .Where(p => p.FarmerId == farmer.Id) // assuming Product has FarmerId FK
        .ToList();

    var model = new FarmerDashboardViewModel
    {
        FullName = farmer.FullName,
        Username = farmer.Username,
        Products = products
    };

    return View(model);
}
 public IActionResult Create()
        {
            return View();
        }
[HttpPost]
[ValidateAntiForgeryToken]
public IActionResult Create(FarmerCreateViewModel model)
{
    if (ModelState.IsValid)
    {
        var farmer = new Farmer
        {
            Username = model.Username,
            FullName = model.FullName,
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(model.Password) // Hash the password
        };

        _context.Farmers.Add(farmer);
        _context.SaveChanges();
        return RedirectToAction(nameof(Index));
    }

    return View(model); // FIX: return the same ViewModel type
}




        // GET: /Farmer/Edit/5
        public IActionResult Edit(int id)
        {
            var farmer = _context.Farmers.Find(id);
            if (farmer == null)
                return NotFound();

            var viewModel = new FarmerEditViewModel
            {
                Id = farmer.Id,
                FullName = farmer.FullName,
                Username = farmer.Username
            };

            return View(viewModel);
        }

        // POST: /Farmer/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(FarmerEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var existingFarmer = _context.Farmers.Find(model.Id);
                if (existingFarmer == null)
                    return NotFound();

                existingFarmer.FullName = model.FullName;
                existingFarmer.Username = model.Username;

                _context.SaveChanges();
                TempData["SuccessMessage"] = "Farmer updated successfully!";
                return RedirectToAction(nameof(Index));
            }

            TempData["ErrorMessage"] = "Failed to update farmer.";
            return View(model);
        }

        // GET: /Farmer/Delete/5
        public IActionResult Delete(int id)
        {
            var farmer = _context.Farmers.Find(id);
            if (farmer == null)
                return NotFound();

            return View(farmer);
        }

        // POST: /Farmer/DeleteConfirmed/5
        [HttpPost, ActionName("DeleteConfirmed")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var farmer = _context.Farmers.Find(id);
            if (farmer == null)
                return NotFound();

            _context.Farmers.Remove(farmer);
            _context.SaveChanges();
            TempData["SuccessMessage"] = "Farmer deleted successfully!";
            return RedirectToAction(nameof(Index));
        }


        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }

    }
    
}
