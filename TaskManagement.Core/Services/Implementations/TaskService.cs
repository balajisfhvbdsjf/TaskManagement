using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskManagement.Core.Interfaces;
using TaskManagement.Domain.DTOs;

namespace TaskManagement.Core.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;

        public TaskService(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public async Task<IEnumerable<ETaskDTO>> GetAllTasksAsync()
        {
            return await _taskRepository.GetAllTasksAsync();
        }

        public async Task<ETaskDTO> GetTaskByIdAsync(int id)
        {
            return await _taskRepository.GetTaskByIdAsync(id);
        }

        public async Task<ETaskDTO> CreateTaskAsync(ETaskDTO EtaskDTO)
        {
            return await _taskRepository.CreateTaskAsync(EtaskDTO);
        }

        public async Task<ETaskDTO> UpdateTaskAsync(int id, ETaskDTO EtaskDTO)
        {
            return await _taskRepository.UpdateTaskAsync(id, EtaskDTO);
        }

        public async Task<bool> DeleteTaskAsync(int id)
        {
            return await _taskRepository.DeleteTaskAsync(id);
        }
    }
}
