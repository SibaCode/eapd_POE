using Microsoft.AspNetCore.Identity;

namespace AgriEnergyConnect.Models
{
    public class ApplicationUser : IdentityUser
    {
        // Add custom properties if needed, like Role or FullName
        public string FullName { get; set; }
        public string Role { get; set; } // "Farmer", "Expert", "TechProvider"
    }
}
