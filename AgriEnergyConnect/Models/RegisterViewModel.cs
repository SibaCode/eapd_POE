using System.ComponentModel.DataAnnotations;
namespace AgriEnergyConnect.Models
{
 public class RegisterViewModel
{
    public string FullName { get; set; }
    public string Username { get; set; }

    [DataType(DataType.Password)]
    public string Password { get; set; }
}

}
