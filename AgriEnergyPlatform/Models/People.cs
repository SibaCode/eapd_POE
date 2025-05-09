
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AgriEnergyPlatform.Models
{    
    
   public class People
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string PasswordHash { get; set; }
    public string Role { get; set; } 
    public DateTime CreatedAt { get; set; }
 // Admin, Farmer, Vendor, Expert
}


}

