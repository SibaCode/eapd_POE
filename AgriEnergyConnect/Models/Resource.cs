using System.ComponentModel.DataAnnotations;
namespace AgriEnergyConnect.Models
{
public class Resource
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
     public DateTime UploadDate { get; set; } = DateTime.UtcNow;

        // Optional: Link to file or resource (can be a PDF, YouTube video, etc.)
        public string FileUrl { get; set; }
}


}
