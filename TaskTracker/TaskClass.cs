namespace TaskTracker;

public record TaskClass {
    public required int ID { get; set; }
    public required string Description { get; set; }
    public string status { get; set; } = "todo";
    public string? CreatedAt { get; set; } = null;
    public string? UpdatedAt { get; set; } = null;

}
