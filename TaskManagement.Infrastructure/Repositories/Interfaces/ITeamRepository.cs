using System.Collections.Generic;
using System.Threading.Tasks;
using TaskManagement.Domain.Entities;

namespace TaskManagement.Core.Repositories.Interfaces
{
    public interface ITeamRepository
    {
        Task<Team> GetTeamByIdAsync(int id);
        Task<IEnumerable<Team>> GetAllTeamsAsync();
        Task<Team> CreateTeamAsync(Team team);
        Task<Team> UpdateTeamAsync(int id, Team team);
        Task<bool> DeleteTeamAsync(int id);
    }
}
