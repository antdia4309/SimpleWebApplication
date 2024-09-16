/**********************************************************
* Name: Antonio Diaz
* Date: 9/12/2024
* Assignment: SDC320 Course Project - Class Implementation
*
*/

public class TaskManager : ITaskManager
{
    public List<TaskBase> Tasks { get; }

    public TaskManager()
    {
        Tasks = new List<TaskBase>();
    }

    public void AddTask(TaskBase task)
    {
        Tasks.Add(task);
        Console.WriteLine($"\nTask {task.TaskName} added successfully.\n");
    }

    public void ViewTasks()
    {
        foreach (var task in Tasks)
        {
            task.DisplayInfo();
        }
    }

    public void UpdateTask(int taskId)
    {
        var task = Tasks.Find(t => t.TaskId == taskId);
        
        if (task != null)
        {
            Console.WriteLine($"\nUpdate the task {taskId}, task name:");
            task.TaskName = Console.ReadLine();
            Console.WriteLine($"\nUpdated {taskId} successfully.\n");
        }
        else
        {
            Console.WriteLine($"\nTask {taskId} not found.\n");
        }
    }

    public void DeleteTask(int taskId)
    {
        var task = Tasks.Find(t => t.TaskId == taskId);
        
        if (task != null)
        {
            Tasks.Remove(task);
            Console.WriteLine($"\nTask {taskId} deleted.\n");
        }
        else
        {
            Console.WriteLine($"\nTask {taskId} not found.\n");
        }
    }
}