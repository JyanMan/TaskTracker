using System.Text.Json;

namespace TaskTracker;

public class Program {
    static void Main(string[] args) {
        TaskManager taskManager = new();    
        switch (args[0]) 
        {
            case "add":
                if (args[1] == null || args[1] == "") 
                {
                    Console.WriteLine("Input a parameter");
                    return;
                }
                taskManager.Add(args[1]);
                break;
            case "list":
                taskManager.ListTasks();
                break;
            case "remove":
                taskManager.Delete(Convert.ToInt32(args[1]));
                break;
            default:
                break;
        }

        taskManager.End();
    }
}

class TaskManager {
    public Dictionary<int, TaskClass> Tasks = [];
    public Dictionary<int, TaskClass> OngoingTasks = [];
    private int currID = 0;
    string filePath = "TasksList.json";

    public TaskManager() 
    {
        Init(); 
    }

    private void Init()
    {
        if (File.Exists(filePath)) 
        {
            string fileContent = File.ReadAllText(filePath);
            Tasks = JsonSerializer.Deserialize<Dictionary<int, TaskClass>>(fileContent) ?? [];
            foreach (var task in Tasks) 
            {
                if (task.Value.ID >= currID)
                {
                    currID = task.Value.ID+1;
                }
            }
        }
    }

    public void Add(string taskDesc) 
    {
        TaskClass newTask = new() { ID = currID, Description = taskDesc };
        Tasks.Add(currID, newTask);
        currID++;
    }

    public void Delete(int givenID)
    {
        Tasks.Remove(givenID);
    }
    

    public void ListTasks() 
    {
        foreach (var task in Tasks) 
        {
            Console.WriteLine("*" + task.Value.Description + " (ID: " + task.Value.ID + ")");
        }
    }

    public void End() 
    {
        string newFileContent = JsonSerializer.Serialize(Tasks, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(filePath, newFileContent);
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
