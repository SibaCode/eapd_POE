using System.ComponentModel.DataAnnotations;

namespace AgriEnergyConnect.Models
{
  public class FarmerCreateViewModel
{
    [Required]
    public string FullName { get; set; }

    [Required]
    public string Username { get; set; }

    [Required, DataType(DataType.Password)]
    public string Password { get; set; }
}

}
