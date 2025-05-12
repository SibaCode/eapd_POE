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
            return View();
        }

        // POST: /Product/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Products.Add(product);
                _context.SaveChanges();
                TempData["SuccessMessage"] = "Product created successfully!";
                return RedirectToAction(nameof(Index));
            }

            TempData["ErrorMessage"] = "Failed to create product.";
            return View(product);
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
