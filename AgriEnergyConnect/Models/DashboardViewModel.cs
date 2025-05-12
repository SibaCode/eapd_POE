using System.ComponentModel.DataAnnotations;
namespace AgriEnergyConnect.Models
{
   public class DashboardViewModel
{
    public int TotalFarmers { get; set; }
    public int TotalProducts { get; set; }
    public string LoggedInEmployeeName { get; set; }
      // Filter input
    public string CategoryFilter { get; set; }
    public bool? InStockFilter { get; set; }

    // Filtered product results
    public List<Product> FilteredProducts { get; set; }

}

}
