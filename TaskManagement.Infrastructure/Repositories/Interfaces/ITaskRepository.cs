using System.Collections.Generic;
using System.Threading.Tasks;
using TaskManagement.Domain.DTOs;

namespace TaskManagement.Core.Interfaces
{
    public interface ITaskRepository
    {
        Task<IEnumerable<ETaskDTO>> GetAllTasksAsync();
        Task<ETaskDTO> GetTaskByIdAsync(int id);
        Task<ETaskDTO> CreateTaskAsync(ETaskDTO EtaskDTO);
        Task<ETaskDTO> UpdateTaskAsync(int id, ETaskDTO EtaskDTO);
        Task<bool> DeleteTaskAsync(int id);
    }
}
