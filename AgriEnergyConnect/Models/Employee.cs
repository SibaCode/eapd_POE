using System.ComponentModel.DataAnnotations;
namespace AgriEnergyConnect.Models
{
   public class Employee
{
    public int Id { get; set; }
    public string FullName { get; set; }
    public string Username { get; set; }
    public string Password { get; set; } // Also to be hashed
}


}
