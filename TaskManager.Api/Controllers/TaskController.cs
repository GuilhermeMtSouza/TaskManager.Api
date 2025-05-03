using Microsoft.AspNetCore.Mvc;
using TaskManager.Application.DTOs.Request.Task;
using TaskManager.Application.Interfaces;
using TaskManager.Domain.Models;

namespace TaskManager.Api.Controllers
{
    public class TaskController : BaseController
    {
        private readonly ITaskService _taskService;
        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpGet]
        public async Task<IActionResult> GetTask()
        {
            return Ok(await _taskService.GetAllTasksAsync());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTaskById(Guid id)
        {
            var task = await _taskService.GetById(id);
            if (task == null)
            {
                return NotFound();
            }
            return Ok(task);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] RequestCreateTaskDto taskModel)
        {
            return Ok(await _taskService.Add(taskModel));
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] TaskModel taskModel)
        {
            return Ok(await _taskService.Update(taskModel));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            return Ok(await _taskService.Delete(id));
        }
    }
}
