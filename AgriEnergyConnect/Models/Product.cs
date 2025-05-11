using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgriEnergyConnect.Models
{
public class Product
{
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    public string Category { get; set; }
   
    [Required]
     public decimal Price { get; set; } // New
    public bool InStock { get; set; } 
  [Required]
        [DataType(DataType.Date)]
        public DateTime ProductionDate { get; set; }

    public int FarmerId { get; set; }
}


}
