using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using AgriEnergyPlatform.Models;
using System.Threading.Tasks;
using System.Linq;
using AgriEnergyPlatform.Data;
using Microsoft.AspNetCore.Authorization;

namespace AgriEnergyConnect.Controllers
{
    [Authorize(Roles = "Farmer")]
public class FarmerController : Controller
{
    private readonly ApplicationDbContext _context;

    public FarmerController(ApplicationDbContext context)
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