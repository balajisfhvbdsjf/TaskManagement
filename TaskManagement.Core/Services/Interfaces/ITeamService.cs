using TaskManagement.Domain.Entities;

namespace TaskManagement.Core.Services.Interfaces
{
    public interface ITeamService
    {
        Task<Team> GetTeamByIdAsync(int id);
        Task<IEnumerable<Team>> GetAllTeamsAsync();
        Task<Team> CreateTeamAsync(Team team);
        Task<Team> UpdateTeamAsync(int id, Team team);
        Task<bool> DeleteTeamAsync(int id);
    }
}
