/**********************************************************
* Name: Antonio Diaz
* Date: 9/18/2024
* Assignment: SDC320 Course Project - Database Implementation
*
*/


public abstract class TaskBase
{
    public int TaskId { get; set; }
    public string TaskName { get; set; }
    public DateTime DueDate { get; set; }
    public string Status { get; set; }

    public TaskBase(int taskId, string taskName, DateTime dueDate)
    {
        TaskId = taskId;
        TaskName = taskName;
        DueDate = dueDate;
        Status = "Pending";
    }

    public abstract void DisplayInfo();
}