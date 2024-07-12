
using TaskManagement.Domain.Entities;

namespace TaskManagement.Core.Services.Interfaces
{
    public interface ITaskService
    {
        Task<ETask> GetTaskByIdAsync(int id);
        Task<IEnumerable<ETask>> GetAllTasksAsync();
        Task<ETask> CreateTaskAsync(ETask Etask);
        Task<ETask> UpdateTaskAsync(int id, ETask Etask);
        Task<bool> DeleteTaskAsync(int id);
    }
}
