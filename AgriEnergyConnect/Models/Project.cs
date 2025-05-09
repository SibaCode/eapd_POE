public class Project
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Summary { get; set; }
    public string Status { get; set; } // Proposed, Active, Completed
    public int CreatedById { get; set; }
    public User CreatedBy { get; set; }
}
