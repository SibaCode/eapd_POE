
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AgriEnergyPlatform.Models
{    
    public class Content
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Type { get; set; } // Webinars, Articles, etc.
}


}

