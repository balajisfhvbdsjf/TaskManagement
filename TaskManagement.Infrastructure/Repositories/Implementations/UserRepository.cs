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
    public class UserRepository : IUserRepository
    {
        private readonly TaskManagementDbContext _context;

        public UserRepository(TaskManagementDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<UserDTO>> GetAllUsersAsync()
        {
            var users = await _context.Users
                .Include(u => u.Team)
                .Select(u => UserToDTO(u))
                .ToListAsync();

            return users;
        }

        public async Task<UserDTO> GetUserByIdAsync(int id)
        {
            var user = await _context.Users
                .Include(u => u.Team)
                .FirstOrDefaultAsync(u => u.Id == id);

            return UserToDTO(user);
        }

        public async Task<UserDTO> CreateUserAsync(UserDTO userDTO)
        {
            var user = new User
            {
                Name = userDTO.Name,
                Email = userDTO.Email,
                TeamId = userDTO.TeamId
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return UserToDTO(user);
        }

        public async Task<UserDTO> UpdateUserAsync(int id, UserDTO userDTO)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);

            if (user == null)
                throw new Exception($"User with id {id} not found");

            user.Name = userDTO.Name;
            user.Email = userDTO.Email;
            user.TeamId = userDTO.TeamId;

            await _context.SaveChangesAsync();

            return UserToDTO(user);
        }

        public async Task<bool> DeleteUserAsync(int id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);

            if (user == null)
                return false;

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return true;
        }

        private static UserDTO UserToDTO(User user) =>
            new UserDTO
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                TeamId = user.TeamId
            };
    }
}
