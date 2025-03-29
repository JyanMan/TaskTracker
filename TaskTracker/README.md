To use the app
1. go the bin/Release/net9.0/publish
2. run cmd
3. for windows to run the app use: TaskTracker [command]

Commands:
 TaskTracker add "task description"
    -- to add a task
 TaskTracker list
    --to list all the tasks
 TaskTracker list [status]
    -- the possible statuses are todo, in-progress, done
    -- this lists all tasks with the specific status
 TaskTracker delete [id of task]
    -- this deletes a task with specific id (to see id of tasks do "TaskTracker list")
 TaskTracker update [id of task] [new task description]
    -- replaces task description with a new specified one (do "TaskTracker list" to see id of tasks)
