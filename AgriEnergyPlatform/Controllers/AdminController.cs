// using Microsoft.AspNetCore.Identity;
// using Microsoft.AspNetCore.Mvc;
// using AgriEnergyPlatform.Models;
// using System.Threading.Tasks;
// using System.Linq;
// using Microsoft.AspNetCore.Authorization;

// using AgriEnergyPlatform.Data;  // Replace with your project namespace


// namespace AgriEnergyConnect.Controllers
// {
// [Authorize(Roles = "Admin")]

// public class AdminController : Controller
// {
//     private readonly ApplicationDbContext _context;

//     public AdminController(ApplicationDbContext context)
//     {
//         _context = context;
//     }
    
//         public IActionResult Dashboard()
//         {
//             return View();
//         }
    

//     public IActionResult Index()
//     {
//         var peoples = _context.Peoples.ToList();
//         return View(peoples);
//     }

//     public IActionResult ManageProducts()
//     {
//         var products = _context.Products.ToList();
//         return View(products);
//     }

//     public IActionResult ManageContent()
//     {
//         var content = _context.Contents.ToList();
//         return View(content);
//     }
// }


// }