using Microsoft.AspNetCore.Mvc;
using AgriEnergyConnect.Models;
using AgriEnergyConnect.Data;

namespace AgriEnergyConnect.Controllers
{
    public class ProductController : Controller
    {
        private readonly AppDbContext _context;

        public ProductController(AppDbContext context)
        {
            _context = context;
        }

        // GET: /Product
        public IActionResult Index()
        {
            var products = _context.Products.ToList();
            return View(products);
        }

        // GET: /Product/Create
        public IActionResult Create()
        {
             var farmerUsername = HttpContext.Session.GetString("FarmerUsername");

        // Check if the user is a farmer
        if (string.IsNullOrEmpty(farmerUsername))
        {
            // If not a farmer, redirect to the employee dashboard or another page
            return RedirectToAction("Dashboard", "Employee"); // Or any page you'd prefer
        }

            return View();
        }

        // POST: /Product/Create
   
[HttpPost]
[ValidateAntiForgeryToken]
public IActionResult Create(Product model)
{
    var farmerUsername = HttpContext.Session.GetString("FarmerUsername");
    if (string.IsNullOrEmpty(farmerUsername)) return RedirectToAction("Login", "Farmer");

    var farmer = _context.Farmers.FirstOrDefault(f => f.Username == farmerUsername);
    if (farmer == null) return RedirectToAction("Login", "Farmer");

    if (ModelState.IsValid)
    {
        model.FarmerId = farmer.Id; // 🔥 only set FarmerId, don't worry about model.Farmer
        _context.Products.Add(model);
        _context.SaveChanges();

        return RedirectToAction("Dashboard", "Farmer");
    }

    return View(model);
}
        // GET: /Product/Edit/5
        public IActionResult Edit(int id)
        {
            var product = _context.Products.Find(id);
            if (product == null)
                return NotFound();

            return View(product);
        }

        // POST: /Product/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Product updatedProduct)
        {
            if (id != updatedProduct.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                var existingProduct = _context.Products.Find(id);
                if (existingProduct == null)
                    return NotFound();

                existingProduct.Name = updatedProduct.Name;
                existingProduct.Category = updatedProduct.Category;
                existingProduct.Price = updatedProduct.Price;
                existingProduct.InStock = updatedProduct.InStock;
                existingProduct.ProductionDate = updatedProduct.ProductionDate;

                _context.SaveChanges();
                TempData["SuccessMessage"] = "Product updated successfully!";
                return RedirectToAction(nameof(Index));
            }

            TempData["ErrorMessage"] = "Failed to update product.";
            return View(updatedProduct);
        }

   // GET: /Product/Delete/5
public IActionResult Delete(int id)
{
    var product = _context.Products.Find(id);
    if (product == null)
        return NotFound();

    return View(product);  // Pass the product to the view
}

// POST: /Product/DeleteConfirmed/5
[HttpPost, ActionName("DeleteConfirmed")]
[ValidateAntiForgeryToken]
public IActionResult DeleteConfirmed(int id)
{
    var product = _context.Products.Find(id);
    if (product == null)
        return NotFound();

    _context.Products.Remove(product);
    _context.SaveChanges();
    TempData["SuccessMessage"] = "Product deleted successfully!";
    return RedirectToAction(nameof(Index));
}


    }
}
