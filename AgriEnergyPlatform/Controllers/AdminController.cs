using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using AgriEnergyPlatform.Models;
using System.Threading.Tasks;
using System.Linq;
using AgriEnergyPlatform.Data;  // Replace with your project namespace


namespace AgriEnergyConnect.Controllers
{

public class AdminController : Controller
{
    private readonly ApplicationDbContext _context;

    public AdminController(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var users = _context.Users.ToList();
        return View(users);
    }

    public IActionResult ManageProducts()
    {
        var products = _context.Products.ToList();
        return View(products);
    }

    public IActionResult ManageContent()
    {
        var content = _context.Contents.ToList();
        return View(content);
    }
}


}