namespace TaskTracker;

public record TaskClass {
    public required int ID { get; set; }
    public required string Description { get; set; }
    public string status { get; set; } = "todo";
    public required string CreatedAt { get; set; }
    public required string UpdatedAt { get; set; }
}
