using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using AgriEnergyPlatform.Models;
using System.Threading.Tasks;
using System.Linq;
using AgriEnergyPlatform.Data;
using Microsoft.AspNetCore.Authorization;

namespace AgriEnergyConnect.Controllers
{
        [Authorize(Roles = "Vendor")]

public class VendorController : Controller
{
    private readonly ApplicationDbContext _context;

    public VendorController(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult Dashboard()
    {
        return View();
    }

    public IActionResult AddProduct()
    {
        return View();
    }
}




}