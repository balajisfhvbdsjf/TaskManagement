using System.Collections.Generic;
using System.Threading.Tasks;
using TaskManagement.Core.Repositories.Interfaces;
using TaskManagement.Core.Services.Interfaces;
using TaskManagement.Domain.Entities;

namespace TaskManagement.Core.Services
{
    public class TeamService : ITeamService
    {
        private readonly ITeamRepository _teamRepository;

        public TeamService(ITeamRepository teamRepository)
        {
            _teamRepository = teamRepository;
        }

        public async Task<Team> GetTeamByIdAsync(int id)
        {
            return await _teamRepository.GetTeamByIdAsync(id);
        }

        public async Task<IEnumerable<Team>> GetAllTeamsAsync()
        {
            return await _teamRepository.GetAllTeamsAsync();
        }

        public async Task<Team> CreateTeamAsync(Team team)
        {
            return await _teamRepository.CreateTeamAsync(team);
        }

        public async Task<Team> UpdateTeamAsync(int id, Team team)
        {
            return await _teamRepository.UpdateTeamAsync(id, team);
        }

        public async Task<bool> DeleteTeamAsync(int id)
        {
            return await _teamRepository.DeleteTeamAsync(id);
        }
    }
}
