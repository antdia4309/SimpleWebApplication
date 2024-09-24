/**********************************************************
* Name: Antonio Diaz
* Date: 9/18/2024
* Assignment: SDC320 Course Project - Database Implementation
*
*/

using System.Data.SQLite;

class CourseProject
{
    static void Main(string[] args)
    {
        using (var conn = new SQLiteConnection("Data Source=taskmanager.db"))
        {
            conn.Open();

            TasksDb.CreateTable(conn);

            TaskManager manager = new TaskManager();

            WorkTask workTask1 = new WorkTask(1, "Code Review", DateTime.Now.AddDays(2), "New Project");
            WorkTask workTask2 = new WorkTask(2, "Sprint Review", DateTime.Now.AddDays(5), "Upcoming Sprint");
            
            PersonalTask personalTask1 = new PersonalTask(3, "Grocery Shopping", DateTime.Now.AddDays(1), "Home");
            PersonalTask personalTask2 = new PersonalTask(4, "Gym", DateTime.Now.AddDays(2), "Fitness");
            PersonalTask personalTask3 = new PersonalTask(5, "Make Lunch", DateTime.Now.AddDays(1), "Hobby");

            manager.AddTask(conn, workTask1);
            manager.AddTask(conn, workTask2);

            manager.AddTask(conn, personalTask1);
            manager.AddTask(conn, personalTask2);
            manager.AddTask(conn, personalTask3);

            manager.ViewTasks(conn);

            manager.UpdateTask(conn, 1, "Code Review", DateTime.Now.AddDays(3), "Completed");
            manager.UpdateTask(conn, 5, "Make Dinner", DateTime.Now.AddDays(1), "Pending");

            manager.DeleteTask(conn, 2);
            manager.DeleteTask(conn, 3);

            manager.ViewTasks(conn);
        }
    }
}