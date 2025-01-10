using LevelUp.Models;
using System.Collections.Generic;

namespace LevelUp.Interfaces
{
    public interface ITaskRepository
    {
        ICollection<LevelUp.Models.Task> GetTasks();
        LevelUp.Models.Task GetTaskById(int id);
        bool AddTask(LevelUp.Models.Task task);
        bool UpdateTask(LevelUp.Models.Task task);
        bool DeleteTask(int id);
        bool AssignTaskToUser(int taskId, int userId);
        bool CompleteTask(int taskId, int userId);

        ICollection<LevelUp.Models.Task> GetTasksAssignedToUser(int userId);
        bool Save();
    }
}
