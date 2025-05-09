using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using AgriEnergyPlatform.Models;
using System.Threading.Tasks;
using System.Linq;
using AgriEnergyPlatform.Data;

namespace AgriEnergyConnect.Controllers
{
public class ExpertController : Controller
{
    private readonly ApplicationDbContext _context;

    public ExpertController(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult ManageContent()
    {
        var content = _context.Contents.ToList();
        return View(content);
    }

    public IActionResult AddContent()
    {
        return View();
    }
}

}