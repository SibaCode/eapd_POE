using System.ComponentModel.DataAnnotations;

namespace AgriEnergyConnect.Models
{
    public class MarketplaceItem
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        [Required]
        public decimal Price { get; set; }

        public string VendorName { get; set; }

        public bool InStock { get; set; }
    }
}
