using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AgriEnergyPlatform.Models
{
    public class Farm
    {
        public int FarmId { get; set; }

        [Required]
        public string FarmName { get; set; }

        public string Location { get; set; }

        public string FarmDescription { get; set; }

        public string ContactInfo { get; set; }

        // Foreign Key to People (Farmer)
        public int PeopleId { get; set; }
        public virtual People People { get; set; }

        // Navigation property for related Products (One-to-many)
    }
}
