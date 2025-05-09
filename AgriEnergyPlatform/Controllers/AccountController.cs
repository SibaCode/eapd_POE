using Microsoft.AspNetCore.Mvc;
using AgriEnergyPlatform.Models;
using AgriEnergyPlatform.Data;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using BCrypt.Net;
using Microsoft.EntityFrameworkCore;


namespace AgriEnergyPlatform.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AccountController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: /Account/Login
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        // POST: /Account/Login
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
{
    if (ModelState.IsValid)
    {
        // Check if the people exists
        var people = await _context.Peoples.FirstOrDefaultAsync(u => u.Username == model.Username);
        
        // If people not found
        if (people == null || !BCrypt.Net.BCrypt.Verify(model.Password, people.PasswordHash))
        {
            ModelState.AddModelError("", "Invalid Username or password.");
            return View(model);
        }

        // Authenticate and sign-in the people
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, people.Username),
            new Claim(ClaimTypes.Role, people.Role) // Store role in claims
        };

        var claimsIdentity = new ClaimsIdentity(claims, "Login");
        var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
        
        // Sign the people in
        await HttpContext.SignInAsync("Cookies", claimsPrincipal);

        // Redirect based on role
        switch (people.Role)
        {
            case "Admin":
                return RedirectToAction("Dashboard", "Admin");
            case "Farmer":
                return RedirectToAction("Dashboard", "Farmer");
            case "Vendor":
                return RedirectToAction("Dashboard", "Vendor");
            case "Expert":
                return RedirectToAction("Dashboard", "Expert");
            default:
                return RedirectToAction("Index", "Home"); // Default if role is not recognized
        }
    }

    // If the model is not valid, return the view with validation messages
    return View(model);
}
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Account");
        }
    }
}
