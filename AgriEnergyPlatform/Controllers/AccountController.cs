using Microsoft.AspNetCore.Mvc;
using AgriEnergyPlatform.Models;
using AgriEnergyPlatform.Data;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using BCrypt.Net;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;


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
[Authorize(Roles = "Admin")]
public IActionResult AdminDashboard()
{
    return View();
}

[Authorize(Roles = "Farmer")]
public IActionResult FarmerDashboard()
{
    return View();
}

[Authorize(Roles = "Vendor")]
public IActionResult VendorDashboard()
{
    return View();
}

[Authorize(Roles = "Expert")]
public IActionResult ExpertDashboard()
{
    return View();
}

        // POST: /Account/Login
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Check if the user exists
                var people = await _context.Peoples.FirstOrDefaultAsync(u => u.Username == model.Username);

                // If user not found or password is incorrect
                if (people == null || !BCrypt.Net.BCrypt.Verify(model.Password, people.PasswordHash))
                {
                    ModelState.AddModelError("", "Invalid Username or password.");
                    return View(model);
                }

                // Create claims identity for the user
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, people.Username),
                    new Claim(ClaimTypes.Role, people.Role) // Store role in claims
                };

                var claimsIdentity = new ClaimsIdentity(claims, "Login");
                var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

                // Sign the user in
                await HttpContext.SignInAsync("Cookies", claimsPrincipal);

                // Redirect based on user role
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

        // Logout method
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Account");
        }
         public IActionResult AccessDenied()
    {
        return View();
    }

        
    }
}
