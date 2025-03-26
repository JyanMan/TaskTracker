using System.Collections.Generic;

namespace TaskTracker;

public class Program {
    static void Main(string[] args) {
        Console.WriteLine("Hello World!");

        TaskManager taskManager = new();
        taskManager.Init();
    }
}

class TaskManager {
    public Dictionary<string, string> Tasks = [];
    public TaskManager() {}

    public void Init() {
        int chosenFunction = -1;
        do {
            Console.WriteLine("Choose From the following Functions");
            Console.WriteLine("0. Exit");
            Console.WriteLine("1. List Task");
            Console.WriteLine("2. Add Task");
            Console.WriteLine("3. Delete Task");
            chosenFunction = Convert.ToInt32(Console.ReadLine());

            switch (chosenFunction) {
                case 1:
                    ListTasks();
                    break;
                case 2:
                    Add();
                    break;
                default:
                    break;
            }
        } while (chosenFunction != 0);
    }

    public void ListTasks() {
        Console.WriteLine("The following are the tasks");
        int increment = 0;
        foreach (KeyValuePair<string, string> task in  Tasks) {
            increment++;
            Console.WriteLine(increment + ". " + task.Key + " -> " + task.Value);
        }
        if (Tasks.Count <= 0) {
            Console.WriteLine("There are no current task");
        }
        Console.WriteLine("***************************** \n");
    }

    public void Add() {
        Console.WriteLine("Input Task name");
        string? taskName = Console.ReadLine();
        Console.WriteLine("Input task description");
        string? taskDescription = Console.ReadLine();

        // Task newTask = new();

        Tasks.Add(taskName, taskDescription);
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
