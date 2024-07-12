using System.Collections.Generic;
using System.Threading.Tasks;
using TaskManagement.Domain.Entities;


namespace TaskManagement.Core.Repositories.Interfaces
{
    public interface ITaskRepository
    {
        Task<ETask> GetTaskByIdAsync(int id);
        Task<IEnumerable<ETask>> GetAllTasksAsync();
        Task<ETask> CreateTaskAsync(ETask Etask);
        Task<ETask> UpdateTaskAsync(int id, ETask Etask);
        Task<bool> DeleteTaskAsync(int id);
    }
}
