
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using AgriEnergyConnect.Models;

namespace AgriEnergyConnect.Models

{
public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public string Category { get; set; }
    public string ImageUrl { get; set; }

    public string SellerId { get; set; }
    public ApplicationUser Seller { get; set; }
}
}

