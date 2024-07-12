using System.Collections.Generic;
using System.Threading.Tasks;
using TaskManagement.Domain.Entities;
using Task = TaskManagement.Domain.Entities.Task;

namespace TaskManagement.Core.Repositories.Interfaces
{
    public interface ITaskRepository
    {
        Task<Task> GetTaskByIdAsync(int id);
        Task<IEnumerable<Task>> GetAllTasksAsync();
        Task<Task> CreateTaskAsync(Task task);
        Task<Task> UpdateTaskAsync(int id, Task task);
        Task<bool> DeleteTaskAsync(int id);
    }
}
