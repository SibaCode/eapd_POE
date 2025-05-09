using Microsoft.AspNetCore.Identity;
using AgriEnergyConnect.Models;

namespace AgriEnergyConnect.Models
{
public class ApplicationUser : IdentityUser
{
    public string FullName { get; set; }
    public string Role { get; set; } // Farmer, Expert, TechProvider
}
}