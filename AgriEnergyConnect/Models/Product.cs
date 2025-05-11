using System.ComponentModel.DataAnnotations;
namespace AgriEnergyConnect.Models
{
public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Category { get; set; }
     public decimal Price { get; set; } // New
    public bool InStock { get; set; } 

    public int FarmerId { get; set; }
}


}
