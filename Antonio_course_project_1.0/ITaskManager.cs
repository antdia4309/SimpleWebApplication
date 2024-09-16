/**********************************************************
* Name: Antonio Diaz
* Date: 9/12/2024
* Assignment: SDC320 Course Project - Class Implementation
*
*/

public interface ITaskManager
{
    void AddTask(TaskBase task);
    void ViewTasks();
    void UpdateTask(int taskId);
    void DeleteTask(int taskId);
}