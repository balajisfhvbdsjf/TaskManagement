using System.Collections.Generic;
using System.Threading.Tasks;
using TaskManagement.Core.Interfaces;
using TaskManagement.Domain.DTOs;

namespace TaskManagement.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<UserDTO>> GetAllUsersAsync()
        {
            return await _userRepository.GetAllUsersAsync();
        }

        public async Task<UserDTO> GetUserByIdAsync(int id)
        {
            return await _userRepository.GetUserByIdAsync(id);
        }

        public async Task<UserDTO> CreateUserAsync(UserDTO userDTO)
        {
            return await _userRepository.CreateUserAsync(userDTO);
        }

        public async Task<UserDTO> UpdateUserAsync(int id, UserDTO userDTO)
        {
            return await _userRepository.UpdateUserAsync(id, userDTO);
        }

        public async Task<bool> DeleteUserAsync(int id)
        {
            return await _userRepository.DeleteUserAsync(id);
        }
    }
}
