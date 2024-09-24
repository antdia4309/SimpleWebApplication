/**********************************************************
* Name: Antonio Diaz
* Date: 9/18/2024
* Assignment: SDC320 Course Project - Database Implementation
*
*/

using System.Data.SQLite;

public interface ITaskManager
{
    void AddTask(SQLiteConnection conn, TaskBase task);
    void ViewTasks(SQLiteConnection conn);
    void UpdateTask(SQLiteConnection conn, int taskId, string newTaskName, DateTime newDueDate, string newStatus);
    void DeleteTask(SQLiteConnection conn, int taskId);
}