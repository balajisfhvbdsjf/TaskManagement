using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskManagement.Core.Interfaces;
using TaskManagement.Domain.DTOs;

namespace TaskManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly ITaskService _taskService;

        public TasksController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        // GET: api/Tasks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ETaskDTO>>> GetTasks()
        {
            var Etasks = await _taskService.GetAllTasksAsync();
            return Ok(Etasks);
        }

        // GET: api/Tasks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ETaskDTO>> GetTask(int id)
        {
            var Etask = await _taskService.GetTaskByIdAsync(id);

            if (Etask == null)
            {
                return NotFound();
            }

            return Ok(Etask);
        }

        // POST: api/Tasks
        [HttpPost]
        public async Task<ActionResult<ETaskDTO>> PostTask(ETaskDTO EtaskDTO)
        {
            var createdTask = await _taskService.CreateTaskAsync(EtaskDTO);
            return CreatedAtAction(nameof(GetTask), new { id = createdTask.Id }, createdTask);
        }

        // PUT: api/Tasks/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTask(int id, ETaskDTO EtaskDTO)
        {
            if (id != EtaskDTO.Id)
            {
                return BadRequest();
            }

            try
            {
                var updatedTask = await _taskService.UpdateTaskAsync(id, EtaskDTO);
                return Ok(updatedTask);
            }
            catch (Exception ex)
            {
                // Log the error
                return NotFound();
            }
        }

        // DELETE: api/Tasks/5
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
