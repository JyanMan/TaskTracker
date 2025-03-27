namespace TaskTracker;

public class Program {
    static void Main(string[] args) {
        Console.WriteLine("Hello World!");

        TaskManager taskManager = new();
        taskManager.Init();
    }
}

class TaskManager {
    public Dictionary<int, TaskClass> Tasks = [];
    public Dictionary<int, TaskClass> OngoingTasks = [];
    public TaskManager() {}
    private int currID = 1;

    public void Init() {
        int chosenFunction = -1;
        do {

            Console.WriteLine("0. Exit");
            Console.WriteLine("1. List Task");
            Console.WriteLine("2. List All Tasks in Progress");
            Console.WriteLine("3. List Finished Task");
            Console.WriteLine("4. Add Task");
            Console.WriteLine("5. Delete Task");
            Console.WriteLine("6. Mark Task as done or in progress");
            Console.Write("Choose from the following Functions: ");
            chosenFunction = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("");

            switch (chosenFunction) {
                case 1:
                    ListTasks();
                    break;
                case 2:
                    ListOngoingTasks();
                    break;
                case 3:
                    ListFinishedTasks();
                    break;
                case 4:
                    Add();
                    break;
                case 5:
                    break;
                case 6:
                    SetTaskStatus();
                    break;
                default:
                    break;
            }
        } while (chosenFunction != 0);
    }

    public void ListTasks() {
        int increment = 0;
        Console.WriteLine("The following are the tasks");
        foreach (KeyValuePair<int, TaskClass> task in  Tasks) {
            increment++;
            Console.WriteLine(increment + ". " + WriteTask(task.Value));
        }
        if (Tasks.Count <= 0) {
            Console.WriteLine("There are no current task");
        }
        Console.WriteLine("***************************** \n");
    }

    public void ListOngoingTasks() {
        int increment = 0;
        Console.WriteLine("The following are the tasks");
        foreach (KeyValuePair<int, TaskClass> task in OngoingTasks) {
            increment++;
            Console.WriteLine(increment + ". " + WriteTask(task.Value));
        }
        if (Tasks.Count <= 0) {
            Console.WriteLine("There are no current task");
        }
        Console.WriteLine("***************************** \n");
    }

    public void ListFinishedTasks() {
        int increment = 0;
        Console.WriteLine("The following are the finished tasks:");
        foreach (KeyValuePair<int, TaskClass> task in Tasks) {
            if (!OngoingTasks.ContainsKey(task.Key)) {
                increment++;
                Console.WriteLine(increment + ". " + WriteTask(task.Value));
            }
        }
        Console.WriteLine("******************");
    }

    public void Add() {

        string? taskName;
        string? taskDescription;

        do {
            Console.Write("Input task description: ");
            taskDescription = Console.ReadLine();
            Console.WriteLine("");
            if (taskDescription == null || taskDescription == "") 
            {
                Console.WriteLine("     Invalid Input");
                Console.WriteLine("**********************");
            }
        } while (taskDescription == null || taskDescription == "");

        TaskClass newTask = new(taskDescription, currID);
        Tasks.Add(newTask.ID, newTask);
        OngoingTasks.Add(newTask.ID, newTask);
        Console.WriteLine("Task added successfully (ID: " + newTask.ID + ")");

        currID++;
    }

    public void SetFinishedTask(int id) {
        OngoingTasks[id].SetFinished();
        if (OngoingTasks.ContainsKey(id))
            OngoingTasks.Remove(id);
    }

    public void SetTaskInProgress(int id) {
        Tasks[id].SetOngoing();
        if (!OngoingTasks.ContainsKey(id))
            OngoingTasks.Add(id, Tasks[id]);
    }

    public void SetTaskStatus() {
        ListTasks();
        Console.WriteLine("Indicate the number of the task to change status: ");
        
        int chosenFunction = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("");
        TaskClass chosenTask = Tasks[chosenFunction];
        Console.WriteLine("1. Set to finished");
        Console.WriteLine("2. Set to In Progress ");
        int chosenStatus = Convert.ToInt32(Console.ReadLine());

        switch (chosenStatus) {
            case 1:
                SetFinishedTask(chosenFunction);
                break;
            case 2:
                SetTaskInProgress(chosenFunction);
                break;
        }
    }

    static string WriteTask(TaskClass task) {
        return (task.Description + "(ID: " + task.ID + ")");
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
