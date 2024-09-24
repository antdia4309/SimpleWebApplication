/**********************************************************
* Name: Antonio Diaz
* Date: 9/18/2024
* Assignment: SDC320 Course Project - Database Implementation
*
*/


public class PersonalTask : TaskBase
{
    public string Category { get; set; }

    public PersonalTask(int taskId, string taskName, DateTime dueDate,
        string category) : base(taskId, taskName, dueDate)
    {
        if (string.IsNullOrWhiteSpace(category))
        {
            throw new ArgumentNullException(nameof(category),
                "Category name cannot be null or empty.");
        }
        
        Category = category;
    }

    public override void DisplayInfo()
    {
        Console.WriteLine($"\nPersonal Task: {TaskId}\nName: {TaskName}\nDue: {DueDate}\n" +
            $"Category: {Category}");
    }
}