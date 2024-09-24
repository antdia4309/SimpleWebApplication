/**********************************************************
* Name: Antonio Diaz
* Date: 9/18/2024
* Assignment: SDC320 Course Project - Database Implementation
*
*/

public class WorkTask : TaskBase
{
    public string ProjectName { get; set; }

    public WorkTask(int taskId, string taskName, DateTime dueDate,
        string projectName) : base(taskId, taskName, dueDate)
    {
        if (string.IsNullOrWhiteSpace(projectName))
        {
            throw new ArgumentNullException(nameof(projectName),
                "Project name cannot be null or empty.");
        }
        
        ProjectName = projectName;
}

    public override void DisplayInfo()
    {
        Console.WriteLine($"\nWork Task: {TaskId}\nName: {TaskName}\nDue: {DueDate}\n" +
        $"Project: {ProjectName}");        
    }
}