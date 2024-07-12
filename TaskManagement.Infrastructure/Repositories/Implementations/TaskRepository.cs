using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManagement.Core.Repositories.Interfaces;
using TaskManagement.Domain.Entities;
using TaskManagement.Infrastructure.Data;

namespace TaskManagement.Infrastructure.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly TaskManagementDbContext _dbContext;

        public TaskRepository(TaskManagementDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ETask> GetTaskByIdAsync(int id)
        {
            return await _dbContext.ETasks.FindAsync(id);
        }

        public async Task<IEnumerable<ETask>> GetAllTasksAsync()
        {
            return await _dbContext.ETasks.ToListAsync();
        }

        public async Task<ETask> CreateTaskAsync(ETask Etask)
        {
            _dbContext.ETasks.Add(Etask);
            await _dbContext.SaveChangesAsync();
            return Etask;
        }

        public async Task<ETask> UpdateTaskAsync(int id, ETask Etask)
        {
            _dbContext.Entry(Etask).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return Etask;
        }

        public async Task<bool> DeleteTaskAsync(int id)
        {
            var Etask = await _dbContext.ETasks.FindAsync(id);
            if (Etask == null)
                return false;

            _dbContext.ETasks.Remove(Etask);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
