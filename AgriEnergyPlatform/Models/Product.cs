using System.ComponentModel.DataAnnotations;

namespace AgriEnergyPlatform.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Category { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        // Foreign Key to People (Vendor or Farmer)
        public int PeopleId { get; set; }
        public virtual People People { get; set; }

        // Foreign Key to Farm
        public int FarmId { get; set; }
        public virtual Farm Farm { get; set; }
    }
}
