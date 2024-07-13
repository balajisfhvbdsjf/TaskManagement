using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TaskManagement.Core.Interfaces;
using TaskManagement.Domain.DTOs;
using TaskManagement.Domain.Entities;
using TaskManagement.Infrastructure.Data;

namespace TaskManagement.Infrastructure.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly TaskManagementDbContext _context;

        public TaskRepository(TaskManagementDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ETaskDTO>> GetAllTasksAsync()
        {
            var Etasks = await _context.ETasks
                .Include(t => t.AssignedUser)
                .Select(t => TaskToDTO(t))
                .ToListAsync();

            return Etasks;
        }

        public async Task<ETaskDTO> GetTaskByIdAsync(int id)
        {
            var Etask = await _context.ETasks
                .Include(t => t.AssignedUser)
                .FirstOrDefaultAsync(t => t.Id == id);

            return TaskToDTO(Etask);
        }

        public async Task<ETaskDTO> CreateTaskAsync(ETaskDTO EtaskDTO)
        {
            var Etask = new ETask
            {
                Title = EtaskDTO.Title,
                Description = EtaskDTO.Description,
                //Status = EtaskDTO.Status,
                DueDate = EtaskDTO.DueDate,
                AssignedUserId = EtaskDTO.AssignedUserId
            };

            _context.ETasks.Add(Etask);
            await _context.SaveChangesAsync();

            return TaskToDTO(Etask);
        }

        public async Task<ETaskDTO> UpdateTaskAsync(int id, ETaskDTO EtaskDTO)
        {
            var Etask = await _context.ETasks.FirstOrDefaultAsync(t => t.Id == id);

            if (Etask == null)
                throw new Exception($"Task with id {id} not found");

            Etask.Title = EtaskDTO.Title;
            Etask.Description = EtaskDTO.Description;
            //Etask.Status = EtaskDTO.Status;
            Etask.DueDate = EtaskDTO.DueDate;
            Etask.AssignedUserId = EtaskDTO.AssignedUserId;

            await _context.SaveChangesAsync();

            return TaskToDTO(Etask);
        }

        public async Task<bool> DeleteTaskAsync(int id)
        {
            var Etask = await _context.ETasks.FirstOrDefaultAsync(t => t.Id == id);

            if (Etask == null)
                return false;

            _context.ETasks.Remove(Etask);
            await _context.SaveChangesAsync();

            return true;
        }

        private static ETaskDTO TaskToDTO(ETask Etask) =>
            new ETaskDTO
            {
                Id = Etask.Id,
                Title = Etask.Title,
                Description = Etask.Description,
               // Status = Etask.Status,
                DueDate = Etask.DueDate,
                AssignedUserId = Etask.AssignedUserId,
                AssignedUser = UserToDTO(Etask.AssignedUser)
            };

        private static UserDTO? UserToDTO(User user) =>
            user == null ? null : new UserDTO
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                TeamId = user.TeamId
            };
    }
}
