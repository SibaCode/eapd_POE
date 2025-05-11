using Microsoft.AspNetCore.Mvc;
using AgriEnergyConnect.Models;
using AgriEnergyConnect.Data;
using BCrypt.Net;
using System.Linq;

namespace AgriEnergyConnect.Controllers
{
    public class FarmerController : Controller
    {
        private readonly AppDbContext _context;

        public FarmerController(AppDbContext context)
        {
            _context = context;
        }

        // GET: /Farmer
        public IActionResult Index()
        {
            var farmers = _context.Farmers.ToList();
            return View(farmers);
        }

        // GET: /Farmer/Dashboard
        public IActionResult Dashboard()
        {
            return View();
        }

        // GET: /Farmer/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Farmer/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Farmer farmer)
        {
            if (ModelState.IsValid)
            {
                // Hash the password before saving to the database
                farmer.Password = BCrypt.Net.BCrypt.HashPassword(farmer.Password);
                _context.Farmers.Add(farmer);
                _context.SaveChanges();
                TempData["SuccessMessage"] = "Farmer created successfully!";
                return RedirectToAction(nameof(Index));
            }

            TempData["ErrorMessage"] = "Failed to create farmer.";
            return View(farmer);
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
    }
}
