using LevelUp.Interfaces;
using LevelUp.Models;
using LevelUp.Repository;
using Microsoft.AspNetCore.Mvc;

namespace LevelUp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TasksController : ControllerBase
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IUserRepository _userRepository;

        public TasksController(ITaskRepository taskRepository, IUserRepository userRepository)
        {
            _taskRepository = taskRepository;
            _userRepository = userRepository;
        }


        //Додавання поінтів та хр за завершення таски
        
        [HttpPost("{taskId}/complete")]
        public IActionResult CompleteTask(int taskId, [FromBody] int userId)
        {
            var task = _taskRepository.GetTaskById(taskId);
            if (task == null)
                return NotFound(new { success = false, message = $"Task with ID {taskId} not found." });

            var user = _userRepository.GetUserById(userId);
            if (user == null)
                return NotFound(new { success = false, message = $"User with ID {userId} not found." });

            var taskCompleted = _taskRepository.CompleteTask(taskId, userId);
            if (!taskCompleted)
                return StatusCode(500, new { success = false, message = "Error completing the task." });

            user.XP += task.Points;
            user.Points += task.Points;
            if (!_userRepository.UpdateUser(user))
                return StatusCode(500, new { success = false, message = "Error updating user XP." });

            return Ok(new { success = true, message = "Task marked as completed and XP updated.", data = new { user.XP, task.Points } });
        }
    }
}
