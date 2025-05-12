using System.ComponentModel.DataAnnotations;
namespace AgriEnergyConnect.Models
{
    public class FarmerLoginViewModel
    {
        public int Id { get; set; }

        [Required]
    public string Username { get; set; }

    [Required]
    public string Password { get; set; }
    }
}
