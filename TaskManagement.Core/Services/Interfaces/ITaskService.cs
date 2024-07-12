namespace TaskManagement.Core.Services.Interfaces;
using Task = TaskManagement.Domain.Entities.Task;

{
    public interface ITaskService
    {
        Task<Task> GetTaskByIdAsync(int id);
        Task<IEnumerable<Task>> GetAllTasksAsync();
        Task<Task> CreateTaskAsync(Domain.Entities.Task task);
        Task<Task> UpdateTaskAsync(int id, Domain.Entities.Task task);
        Task<bool> DeleteTaskAsync(int id);
    }
}
