using System.ComponentModel.DataAnnotations;
namespace AgriEnergyConnect.Models
{
public class MarketplaceItem
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Vendor { get; set; }
}


}
