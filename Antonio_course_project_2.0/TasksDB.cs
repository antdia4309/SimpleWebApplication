/**********************************************************
* Name: Antonio Diaz
* Date: 9/18/2024
* Assignment: SDC320 Course Project - Database Implementation
*
*/

using System.Data.SQLite;

public class TasksDb 
{
    public static void CreateTable(SQLiteConnection conn)
    {
        string sql =
            "CREATE TABLE IF NOT EXISTS Tasks (\n"
            + "   TaskId integer PRIMARY KEY\n"
            + "   ,TaskName varchar(50)\n"
            + "   ,DueDate varchar(20)\n"
            + "   ,Status varchar(10)\n"
            + "   ,TaskType varchar(30));";
        
        SQLiteCommand cmd = conn.CreateCommand();
        cmd.CommandText = sql;
        cmd.ExecuteNonQuery();
    }

    public static void AddTask(SQLiteConnection conn, TaskBase t)
    {
        string sql = "INSERT INTO Tasks (TaskName, DueDate, Status, TaskType) "
                     + "VALUES (@taskName, @dueDate, @status, @taskType)";

        using (var cmd = new SQLiteCommand(sql, conn))
        {
            cmd.Parameters.AddWithValue("@taskName", t.TaskName);
            cmd.Parameters.AddWithValue("@dueDate", t.DueDate.ToString("yyyy-MM-dd"));
            cmd.Parameters.AddWithValue("@status", t.Status);
            cmd.Parameters.AddWithValue("@taskType", t.GetType().Name);

            cmd.ExecuteNonQuery();
        }
    }

    public static void UpdateTask(SQLiteConnection conn, int taskId, string newTaskName, DateTime newDueDate, string newStatus)
    {
        string sql = "UPDATE Tasks SET TaskName = @taskName, DueDate = @dueDate, Status = @status WHERE TaskId = @taskId";

        using (var cmd = new SQLiteCommand(sql, conn))
        {
            cmd.Parameters.AddWithValue("@taskName", newTaskName);
            cmd.Parameters.AddWithValue("@dueDate", newDueDate.ToString("yyyy-MM-dd"));
            cmd.Parameters.AddWithValue("@status", newStatus);
            cmd.Parameters.AddWithValue("@taskId", taskId);

            cmd.ExecuteNonQuery();
        }
    }

    public static void DeleteTask(SQLiteConnection conn, int taskId)
    {
        string sql = "DELETE FROM Tasks WHERE TaskId = @taskId";

        using (var cmd = new SQLiteCommand(sql, conn))
        {
            cmd.Parameters.AddWithValue("@taskId", taskId);
            cmd.ExecuteNonQuery();
        }
    }

    public static void ViewTasksFromDatabase(SQLiteConnection conn)
    {
        string sql = "SELECT * FROM Tasks";

        using (var cmd = new SQLiteCommand(sql, conn))
        {
            using (SQLiteDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    Console.WriteLine($"ID: {reader["TaskId"]}\nName: {reader["TaskName"]}\nDue: {reader["DueDate"]}\nStatus: {reader["Status"]}\nType: {reader["TaskType"]}\n");
                }
            }
        }
    }
}