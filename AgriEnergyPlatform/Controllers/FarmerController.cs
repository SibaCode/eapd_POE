using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using AgriEnergyPlatform.Models;
using System.Threading.Tasks;
using System.Linq;
using AgriEnergyPlatform.Data;
namespace AgriEnergyConnect.Controllers
{
public class FarmerController : Controller
{
    private readonly ApplicationDbContext _context;

    public FarmerController(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult Dashboard()
    {
        var products = _context.Products.Where(p => p.VendorId == "FarmerId").ToList();
        return View(products);
    }

    public IActionResult AddProduct()
    {
        return View();
    }
}



}