using System.Text.Json;

namespace TaskTracker;

public class Program {
    static void Main(string[] args) {
        TaskManager taskManager = new();    
        switch (args[0]) 
        {
            case "add":
                if (TaskManager.IsValidParameterCount(2, args.Length))
                    taskManager.Add(args[1]);
                break;
            case "list":
                if (TaskManager.IsValidParameterCount(2, args.Length)) 
                {
                    if (args.Length == 2) {
                        taskManager.ListToDo(args[1]);
                    }
                    else
                        taskManager.ListTasks();
                }
                break;
            case "delete":
                if (TaskManager.IsValidParameterCount(2, args.Length))
                    taskManager.Delete(Convert.ToInt32(args[1]));
                break;
            case "mark-in-progress":
                if (args.Length < 2) 
                {
                    Console.WriteLine("Error: Correct way --> [ID of task] mark-[status]");
                    return;
                }
                taskManager.MarkInProgress(Convert.ToInt32(args[1]));
                break;
            case "mark-done":
                if (args.Length < 2) 
                {
                    Console.WriteLine("Error: Correct way --> [ID of task] mark-[status]");
                    return;
                }
                taskManager.MarkDone(Convert.ToInt32(args[1]));
                break;
            case "update":
                if (args.Length < 3)
                {
                    Console.WriteLine("Error: Correct way --> update [ID of task] [new description]");
                    return;
                }
                taskManager.Update(Convert.ToInt32(args[1]), args[2]);
                break;
            default:
                Console.WriteLine("Invalid command: ");
                for (int i = 0; i < args.Length; i++) {
                    Console.Write( args[i] + " ");
                }
                break;
        }

        taskManager.End();
    }
}

class TaskManager {
    public Dictionary<int, TaskClass> Tasks = [];
    public Dictionary<string, List<TaskClass>> TaskWithStatus = new();
    private int currID = 0;
    string filePath = "TasksList.json";
    public HashSet<string> statuses = new(){"todo", "done", "in-progress"};

    public TaskManager() 
    {
        Init(); 
    }

    private void Init()
    {
        if (File.Exists(filePath)) 
        {
            string fileContent = File.ReadAllText(filePath);
            Tasks = JsonSerializer.Deserialize<Dictionary<int, TaskClass>>(fileContent) ?? new();
            foreach (var task in Tasks) 
            {
                if (task.Value.ID >= currID)
                {
                    currID = task.Value.ID+1;
                }
                string status = task.Value.status;
                if (statuses.Contains(status))
                {
                    if (!TaskWithStatus.ContainsKey(status)) 
                    {
                        TaskWithStatus[status] = new();
                    }
                    TaskWithStatus[status].Add(task.Value);
                }
           }
        }
    }

    public void Add(string taskDesc) 
    {
        if (taskDesc == null || taskDesc == "") 
        {
            Console.WriteLine("Input a parameter");
            return;
        }
        TaskClass newTask = new() { ID = currID, Description = taskDesc };
        Tasks.Add(currID, newTask);
        currID++;
    }

    public void Delete(int givenID)
    {
        if (!Tasks.ContainsKey(givenID))
        {
            Console.WriteLine("Tasks list does not contain task with ID " + givenID);
            return;
        }
        Console.WriteLine(givenID);
        Tasks.Remove(givenID);
        End();
    }
    

    public void ListTasks() 
    {
        foreach (var task in Tasks) 
        {
            Console.WriteLine("*" + task.Value.Description + " (ID: " + task.Value.ID + ")");
        }
    }

    public void ListToDo(string status)
    {
        if (!statuses.Contains(status))
        {
            Console.WriteLine("invalid command, with status " + status);
            return;
        }
        for (int i = 0; i < TaskWithStatus[status].Count; i++)
        {
            TaskClass task = TaskWithStatus[status][i];
            Console.WriteLine("*" + task.Description + " (ID: " + task.ID + ")");
        } 
    }

    public void MarkInProgress(int givenID) 
    {
        if (!Tasks.ContainsKey(givenID))
        {
            Console.WriteLine("task list does not contain task with ID " + givenID);
            return;
        }
        Tasks[givenID].status = "in-progress";
    }

    public void MarkDone(int givenID)
    {
        if (!Tasks.ContainsKey(givenID))
        {
            Console.WriteLine("task list does not contain task with ID " + givenID);
            return;
        }
        Tasks[givenID].status = "done";
    }

    public void Update(int givenID, string newDescription) 
    {
        Tasks[givenID].Description = newDescription; 
    }

    public void End() 
    {
        string newFileContent = JsonSerializer.Serialize(Tasks, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(filePath, newFileContent);
    }

    public static bool IsValidParameterCount(int maxParam, int paramCount) 
    {
        if (paramCount > maxParam)
        {
            Console.WriteLine("error more than max parameter");
            return false;
        }
        return true;
    }
}
    
// The application should run from the command line, accept user actions and inputs as arguments, and store the tasks in a JSON file. The user should be able to:

//     Add, Update, and Delete tasks
//     Mark a task as in progress or done
//     List all tasks
//     List all tasks that are done
//     List all tasks that are not done
//     List all tasks that are in progress

// Here are some constraints to guide the implementation:

//     You can use any programming language to build this project.
//     Use positional arguments in command line to accept user inputs.
//     Use a JSON file to store the tasks in the current directory.
//     The JSON file should be created if it does not exist.
//     Use the native file system module of your programming language to interact with the JSON file.
//     Do not use any external libraries or frameworks to build this project.
//     Ensure to handle errors and edge cases gracefully.

//SAMPLE CODE
// # Adding a new task
// task-cli add "Buy groceries"
// # Output: Task added successfully (ID: 1)

// # Updating and deleting tasks
// task-cli update 1 "Buy groceries and cook dinner"
// task-cli delete 1

// # Marking a task as in progress or done
// task-cli mark-in-progress 1
// task-cli mark-done 1

// # Listing all tasks
// task-cli list

// # Listing tasks by status
// task-cli list done
// task-cli list todo
// task-cli list in-progress

// TASK PROPERTIES

// Each task should have the following properties:

//     id: A unique identifier for the task
//     description: A short description of the task
//     status: The status of the task (todo, in-progress, done)
//     createdAt: The date and time when the task was created
//     updatedAt: The date and time when the task was last updated

// Make sure to add these properties to the JSON file when adding a new task and update them when updating a task.
