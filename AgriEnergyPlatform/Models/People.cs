using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AgriEnergyPlatform.Models
{
    public class People
    {
        public int Id { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string PasswordHash { get; set; }

        public string Role { get; set; } // Admin, Farmer, Vendor, Expert

        public DateTime CreatedAt { get; set; } = DateTime.Now; // Automatically sets created time when a person is created

        // Navigation property for related Farms (One-to-many)
        public ICollection<Farm> Farms { get; set; }

        // Navigation property for related Products (One-to-many)
        public ICollection<Product> Products { get; set; }
    }
}
