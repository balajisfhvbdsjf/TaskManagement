using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskManagement.Core.Services.Interfaces;
using TaskManagement.Domain.Entities;

namespace TaskManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly ITaskService _taskService;

        public TasksController(ITaskService EtaskService)
        {
            _taskService = EtaskService;
        }

        // GET: api/tasks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ETask>>> GetTasks()
        {
            var Etasks = await _taskService.GetAllTasksAsync();
            return Ok(Etasks);
        }

        // GET: api/tasks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ETask>> GetTask(int id)
        {
            var Etask = await _taskService.GetTaskByIdAsync(id);

            if (Etask == null)
            {
                return NotFound();
            }

            return Ok(Etask);
        }

        // POST: api/tasks
        [HttpPost]
        public async Task<ActionResult<ETask>> CreateTask(ETask Etask)
        {
            var createdTask = await _taskService.CreateTaskAsync(Etask);
            return CreatedAtAction(nameof(GetTask), new { id = createdTask.Id }, createdTask);
        }

        // PUT: api/tasks/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTask(int id, ETask Etask)
        {
            if (id != Etask.Id)
            {
                return BadRequest();
            }

            await _taskService.UpdateTaskAsync(id, Etask);

            return NoContent();
        }

        // DELETE: api/tasks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            var result = await _taskService.DeleteTaskAsync(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
