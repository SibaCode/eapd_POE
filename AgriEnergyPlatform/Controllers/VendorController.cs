using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using AgriEnergyPlatform.Models;
using System.Threading.Tasks;
using System.Linq;
using AgriEnergyPlatform.Data;
namespace AgriEnergyConnect.Controllers
{
public class VendorController : Controller
{
    private readonly ApplicationDbContext _context;

    public VendorController(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult ManageProducts()
    {
        var products = _context.Products.Where(p => p.VendorId == "VendorId").ToList();
        return View(products);
    }

    public IActionResult AddProduct()
    {
        return View();
    }
}




}