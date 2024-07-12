namespace TaskManagement.Core.Services.Interfaces
{
    public interface ITaskService
    {
        Task<Task> GetTaskByIdAsync(int id);
        Task<IEnumerable<Task>> GetAllTasksAsync();
        Task<Task> CreateTaskAsync(Task task);
        Task<Task> UpdateTaskAsync(int id, Task task);
        Task<bool> DeleteTaskAsync(int id);
        Task CreateTaskAsync(Domain.Entities.Task task);
    }
}
