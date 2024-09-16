/**********************************************************
* Name: Antonio Diaz
* Date: 9/12/2024
* Assignment: SDC320 Course Project - Class Implementation
*
*/

class CourseProject
{
    static void Main(string[] args)
    {
        TaskManager manager = new TaskManager();

        WorkTask workTask1 = new WorkTask(1, "Code Review", DateTime.Now.AddDays(2), "New Project");
        WorkTask workTask2 = new WorkTask(2, "Sprint Review", DateTime.Now.AddDays(5), "Upcoming Sprint");
        
        PersonalTask personalTask1 = new PersonalTask(3, "Grocery Shopping", DateTime.Now.AddDays(1), "Home");
        PersonalTask personalTask2 = new PersonalTask(4, "Gym", DateTime.Now.AddDays(2), "Fitness");
        PersonalTask personalTask3 = new PersonalTask(5, "Make Lunch", DateTime.Now.AddDays(1), "Hobby");

        manager.AddTask(workTask1);
        manager.AddTask(workTask2);

        manager.AddTask(personalTask1);
        manager.AddTask(personalTask2);
        manager.AddTask(personalTask3);

        manager.ViewTasks();

        manager.UpdateTask(5);

        manager.DeleteTask(2);

        manager.ViewTasks();
    }
}