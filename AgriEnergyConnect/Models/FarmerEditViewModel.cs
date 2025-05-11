using System.ComponentModel.DataAnnotations;
namespace AgriEnergyConnect.Models
{
    public class FarmerEditViewModel
    {
        public int Id { get; set; }

        [Required]
        public string FullName { get; set; }

        [Required]
        public string Username { get; set; }
    }
}
