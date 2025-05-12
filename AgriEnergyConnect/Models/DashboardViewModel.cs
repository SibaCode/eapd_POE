using System.ComponentModel.DataAnnotations;
namespace AgriEnergyConnect.Models
{
   public class DashboardViewModel
{
    public int TotalFarmers { get; set; }
    public int TotalProducts { get; set; }
    public string LoggedInEmployeeName { get; set; }
    public string CategoryFilter { get; set; }
    public bool? InStockFilter { get; set; }

    public List<Product> FilteredProducts { get; set; }

}

}
