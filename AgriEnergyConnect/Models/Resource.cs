using System.ComponentModel.DataAnnotations;
namespace AgriEnergyConnect.Models
{
public class Resource
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
     public DateTime UploadDate { get; set; } = DateTime.UtcNow;

        public string FileUrl { get; set; }
}


}
