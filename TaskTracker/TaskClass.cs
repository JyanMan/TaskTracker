namespace TaskTracker;

public class TaskClass {
    public int ID { get; private set; }
    public string Description { get; private set; }
    public bool InProgress { get; private set; } = false;
    public TaskClass(string description, int newID) {
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