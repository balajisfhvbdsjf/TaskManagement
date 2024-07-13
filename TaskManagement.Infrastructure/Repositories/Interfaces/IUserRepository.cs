using System.Collections.Generic;
using System.Threading.Tasks;
using TaskManagement.Domain.DTOs;

namespace TaskManagement.Core.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<UserDTO>> GetAllUsersAsync();
        Task<UserDTO> GetUserByIdAsync(int id);
        Task<UserDTO> CreateUserAsync(UserDTO userDTO);
        Task<UserDTO> UpdateUserAsync(int id, UserDTO userDTO);
        Task<bool> DeleteUserAsync(int id);
    }
}
