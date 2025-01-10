using LevelUp.Interfaces;
using LevelUp.Models;
using Microsoft.AspNetCore.Mvc;

namespace LevelUp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TasksController : ControllerBase
    {
        private readonly ITaskRepository _taskRepository;

        public TasksController(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        [HttpGet("{id}")]
        public IActionResult GetTaskById(int id)
        {
            var task = _taskRepository.GetTaskById(id);
            if (task == null)
                return NotFound(new { success = false, message = $"Task with ID {id} not found." });

            return Ok(new { success = true, data = task });
        }

        [HttpPost]
        public IActionResult CreateTask([FromBody] LevelUp.Models.Task task)
        {
            if (task == null)
                return BadRequest(new { success = false, message = "Task cannot be null" });

            if (!_taskRepository.AddTask(task))
                return StatusCode(500, new { success = false, message = "Error creating the task" });

            return CreatedAtAction(nameof(GetTaskById), new { id = task.TaskId }, new { success = true, data = task });
        }

        [HttpPut("{id}")]
        public IActionResult UpdateTask(int id, [FromBody] LevelUp.Models.Task task)
        {
            if (id != task.TaskId)
                return BadRequest(new { success = false, message = "ID mismatch" });

            var existingTask = _taskRepository.GetTaskById(id);
            if (existingTask == null)
                return NotFound(new { success = false, message = $"Task with ID {id} not found." });

            if (!_taskRepository.UpdateTask(task))
                return StatusCode(500, new { success = false, message = "Error updating the task" });

            return Ok(new { success = true, data = task });
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTask(int id)
        {
            if (!_taskRepository.DeleteTask(id))
                return NotFound(new { success = false, message = $"Task with ID {id} not found." });

            return Ok(new { success = true });
        }

        [HttpPost("{taskId}/assign/{userId}")]
        public IActionResult AssignTaskToUser(int taskId, int userId)
        {
            var task = _taskRepository.GetTaskById(taskId);
            if (task == null)
                return NotFound(new { success = false, message = $"Task with ID {taskId} not found." });

            if (!_taskRepository.AssignTaskToUser(taskId, userId))
                return StatusCode(500, new { success = false, message = "Error assigning task to user." });

            return Ok(new { success = true, message = "Task successfully assigned." });
        }

        [HttpGet("assigned-to/{userId}")]
        public IActionResult GetTasksAssignedToUser(int userId)
        {
            var tasks = _taskRepository.GetTasksAssignedToUser(userId);
            if (tasks == null || !tasks.Any())
                return NotFound(new { success = false, message = $"No tasks assigned to user with ID {userId}." });

            return Ok(new { success = true, data = tasks });
        }

        [HttpPost("{taskId}/complete")]
        public IActionResult CompleteTask(int taskId, [FromBody] int userId)
        {
            var taskCompleted = _taskRepository.CompleteTask(taskId, userId);
            if (!taskCompleted)
                return NotFound(new { success = false, message = $"Task with ID {taskId} or User with ID {userId} not found." });

            return Ok(new { success = true, message = "Task marked as completed." });
        }

    }
}
