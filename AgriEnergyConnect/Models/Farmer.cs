using System.ComponentModel.DataAnnotations;
namespace AgriEnergyConnect.Models
{
   public class Farmer
{
    public int Id { get; set; }
    public string FullName { get; set; }
    public string Username { get; set; }
    public string PasswordHash { get; set; } 
}

}
