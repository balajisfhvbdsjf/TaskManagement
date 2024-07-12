using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskManagement.Core.Repositories.Interfaces;
using TaskManagement.Domain.Entities;
using TaskManagement.Infrastructure.Data;

namespace TaskManagement.Infrastructure.Repositories
{
    public class TeamRepository : ITeamRepository
    {
        private readonly TaskManagementDbContext _dbContext;

        public TeamRepository(TaskManagementDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Team> GetTeamByIdAsync(int id)
        {
            return await _dbContext.Teams.FindAsync(id);
        }

        public async Task<IEnumerable<Team>> GetAllTeamsAsync()
        {
            return await _dbContext.Teams.ToListAsync();
        }

        public async Task<Team> CreateTeamAsync(Team team)
        {
            _dbContext.Teams.Add(team);
            await _dbContext.SaveChangesAsync();
            return team;
        }

        public async Task<Team> UpdateTeamAsync(int id, Team team)
        {
            _dbContext.Entry(team).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return team;
        }

        public async Task<bool> DeleteTeamAsync(int id)
        {
            var team = await _dbContext.Teams.FindAsync(id);
            if (team == null)
                return false;

            _dbContext.Teams.Remove(team);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
