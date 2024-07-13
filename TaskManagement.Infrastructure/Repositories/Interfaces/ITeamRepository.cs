using System.Collections.Generic;
using System.Threading.Tasks;
using TaskManagement.Domain.DTOs;

namespace TaskManagement.Core.Interfaces
{
    public interface ITeamRepository
    {
        Task<IEnumerable<TeamDTO>> GetAllTeamsAsync();
        Task<TeamDTO> GetTeamByIdAsync(int id);
        Task<TeamDTO> CreateTeamAsync(TeamDTO teamDTO);
        Task<TeamDTO> UpdateTeamAsync(int id, TeamDTO teamDTO);
        Task<bool> DeleteTeamAsync(int id);
    }
}
