This is a project done for https://roadmap.sh/projects/task-tracker

To use the app
1. navigate to TaskTracker\bin\Release\net9.0\publish\
2. There you'll see the actual files
3. I published the whole repo to show my c# code
4. open cmd in that directory
5. for windows to run the app use: TaskTracker.exe [command]

Commands:
 
 TaskTracker.exe add "task description"
    -- to add a task
    
 TaskTracker.exe list
    --to list all the tasks
    
 TaskTracker.exe list [status]
    -- the possible statuses are todo, in-progress, done
    -- this lists all tasks with the specific status
    -- this specifies the id of each task
    
 TaskTracker.exe delete [id of task]
    -- this deletes a task with specific id (to see id of tasks do "TaskTracker list")
    
 TaskTracker.exe update [id of task] [new task description]
    -- replaces task description with a new specified one (do "TaskTracker list" to see id of tasks)

 TaskTracker.exe mark-in-progress [id of task]

 TaskTracker.exe mark-done [id of task]
