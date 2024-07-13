using System.Collections.Generic;
using System.Threading.Tasks;
using TaskManagement.Core.Interfaces;
using TaskManagement.Domain.DTOs;

namespace TaskManagement.Core.Services
{
    public class TeamService : ITeamService
    {
        private readonly ITeamRepository _teamRepository;

        public TeamService(ITeamRepository teamRepository)
        {
            _teamRepository = teamRepository;
        }

        public async Task<IEnumerable<TeamDTO>> GetAllTeamsAsync()
        {
            return await _teamRepository.GetAllTeamsAsync();
        }

        public async Task<TeamDTO> GetTeamByIdAsync(int id)
        {
            return await _teamRepository.GetTeamByIdAsync(id);
        }

        public async Task<TeamDTO> CreateTeamAsync(TeamDTO teamDTO)
        {
            return await _teamRepository.CreateTeamAsync(teamDTO);
        }

        public async Task<TeamDTO> UpdateTeamAsync(int id, TeamDTO teamDTO)
        {
            return await _teamRepository.UpdateTeamAsync(id, teamDTO);
        }

        public async Task<bool> DeleteTeamAsync(int id)
        {
            return await _teamRepository.DeleteTeamAsync(id);
        }
    }
}
