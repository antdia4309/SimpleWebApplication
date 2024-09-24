/**********************************************************
* Name: Antonio Diaz
* Date: 9/18/2024
* Assignment: SDC320 Course Project - Database Implementation
*
*/

using System.Data.SQLite;

public class TaskManager : ITaskManager
{
    public List<TaskBase> Tasks { get; }

    public TaskManager()
    {
        Tasks = new List<TaskBase>();
    }

    public void AddTask(SQLiteConnection conn,  TaskBase task)
    {
        Tasks.Add(task);
        Console.WriteLine($"\nTask {task.TaskName} added successfully.\n");

        TasksDb.AddTask(conn, task);
        Console.WriteLine("Task added to database.");
    }

    public void ViewTasks(SQLiteConnection conn)
    {
        foreach (var task in Tasks)
        {
            task.DisplayInfo();
        }

        Console.WriteLine("\n\nTasks from the database:");
        TasksDb.ViewTasksFromDatabase(conn);
    }

    public void UpdateTask(SQLiteConnection conn, int taskId, string newTaskName, DateTime newDueDate, string newStatus)
    {
        var task = Tasks.Find(t => t.TaskId == taskId);
        
        if (task != null)
        {
            task.TaskName = newTaskName;
            task.DueDate = newDueDate;
            task.Status = newStatus;
            Console.WriteLine($"Task {taskId} updated in memory.\n");
            
            TasksDb.UpdateTask(conn, taskId, newTaskName, newDueDate, newStatus);
            Console.WriteLine("Task updated in database.\n");
        }
        else
        {
            Console.WriteLine($"Task {taskId} not found.\n");
        }
    }

    public void DeleteTask(SQLiteConnection conn, int taskId)
    {
        var task = Tasks.Find(t => t.TaskId == taskId);
        
        if (task != null)
        {
            Tasks.Remove(task);
            Console.WriteLine($"\nTask {taskId} deleted.\n");

            TasksDb.DeleteTask(conn, taskId);
            Console.WriteLine("Task deleted from database.\n");
        }
        else
        {
            Console.WriteLine($"Task {taskId} not found.\n");
        }
    }
}