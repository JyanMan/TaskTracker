namespace TaskTracker;

public class TaskClass {
    public required int ID { get; set; }
    public required string Description { get; set; }
    public string status { get; set; } = "in-progress";
    public string? CreatedAt { get; set; } = null;
    public string? UpdatedAt { get; set; } = null;

}
