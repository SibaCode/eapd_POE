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
        // Retrieve the Farmer's username from the session
        var farmerUsername = HttpContext.Session.GetString("FarmerUsername");

        // Ensure the logged-in user is a farmer
        if (string.IsNullOrEmpty(farmerUsername))
        {
            return RedirectToAction("Dashboard", "Employee");
        }

        if (ModelState.IsValid)
        {
            // Find the farmer from the database
            var farmer = _context.Farmers.FirstOrDefault(f => f.Username == farmerUsername);
            if (farmer != null)
            {
                model.FarmerId = farmer.Id; // Link the product to the farmer
                _context.Products.Add(model); // Add the new product to the database
                _context.SaveChanges(); // Save the changes
                TempData["SuccessMessage"] = "Product created successfully!";
                return RedirectToAction("Index"); // Redirect to the product list or another page
            }
        }

        return View(model); // Return the create view with errors if something went wrong
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
