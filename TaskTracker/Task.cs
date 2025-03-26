namespace TaskTracker;

public class Task {
    public int ID { get; private set; }
    public string Name { get; private set; }
    public string Description { get; private set; }
    public bool InProgress { get; private set; } = false;
    public Task(string name, string description, int newID) {
        Name = name;
        Description = description;
        ID = newID;
    }

    public void SetFinished() {
        InProgress = false;
    }
    public void SetOngoing() {
        InProgress = true;
    }
}