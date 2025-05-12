using System.ComponentModel.DataAnnotations;
namespace AgriEnergyConnect.Models
{
public class Employee
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Username is required.")]
    public string Username { get; set; }

    
    [Required(ErrorMessage = "Full Name is required.")]
    public string FullName { get; set; }
    public string PasswordHash { get; set; }
}


}
