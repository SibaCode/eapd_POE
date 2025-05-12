using System.ComponentModel.DataAnnotations;
namespace AgriEnergyConnect.Models
{
   public class FarmerDashboardViewModel
{
   public string FullName { get; set; }
    public string Username { get; set; }

    public List<Product> Products { get; set; } = new List<Product>();

}

}
