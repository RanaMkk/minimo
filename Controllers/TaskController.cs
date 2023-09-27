using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using minimo.dtos;
using minimo.Services;

namespace minimo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly TaskService _taskService;

        public TaskController(TaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddTaskAsync([FromBody] taskdto taskdto)
        {
            try
            {
                var addedTask = await _taskService.AddTaskAsync(taskdto);
                return Ok(addedTask);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> ListTasksByProjectId(int projectId)
        {
            try
            {
                var tasks = await _taskService.GetTasksByProjectIdAsync(projectId);
                return Ok(tasks);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetTaskDetails")]
        public async Task<IActionResult> GetTaskDetails(int taskId)
        {
            try
            {
                var task = await _taskService.GetTaskAsync(taskId);
                return Ok(task);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("updateTask")]
        public async Task<IActionResult> UpdateTask(int taskId, [FromBody] taskdto updatedTask)
        {
            try
            {
                var updatedTaskResult = await _taskService.UpdateTaskAsync(taskId, updatedTask);
                return Ok(updatedTaskResult);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("changeStatus")]
        public async Task<IActionResult> ChangeTaskStatus(int taskId, [FromBody] int newStatus)
        {
            try
            {
                var updatedTaskResult = await _taskService.ChangeTaskStatusAsync(taskId, newStatus);
                return Ok(updatedTaskResult);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("changePriority")]
        public async Task<IActionResult> ChangeTaskPriority(int taskId, [FromBody] int newPriority)
        {
            try
            {
                var updatedTaskResult = await _taskService.ChangeTaskPriorityAsync(taskId, newPriority);
                return Ok(updatedTaskResult);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("deleteTask")]
        public async Task<IActionResult> DeleteTaskAsync(int taskId)
        {
            try
            {
                 await _taskService.DeleteTaskAsync(taskId);
                return Ok("Task Deleted!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
