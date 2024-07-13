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
    public class TeamRepository : ITeamRepository
    {
        private readonly TaskManagementDbContext _context;

        public TeamRepository(TaskManagementDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TeamDTO>> GetAllTeamsAsync()
        {
            var teams = await _context.Teams
                .Select(t => TeamToDTO(t))
                .ToListAsync();

            return teams;
        }

        public async Task<TeamDTO> GetTeamByIdAsync(int id)
        {
            var team = await _context.Teams.FirstOrDefaultAsync(t => t.Id == id);
            return TeamToDTO(team);
        }

        public async Task<TeamDTO> CreateTeamAsync(TeamDTO teamDTO)
        {
            var team = new Team
            {
                Name = teamDTO.Name
            };

            _context.Teams.Add(team);
            await _context.SaveChangesAsync();

            return TeamToDTO(team);
        }

        public async Task<TeamDTO> UpdateTeamAsync(int id, TeamDTO teamDTO)
        {
            var team = await _context.Teams.FirstOrDefaultAsync(t => t.Id == id);

            if (team == null)
                throw new Exception($"Team with id {id} not found");

            team.Name = teamDTO.Name;

            await _context.SaveChangesAsync();

            return TeamToDTO(team);
        }

        public async Task<bool> DeleteTeamAsync(int id)
        {
            var team = await _context.Teams.FirstOrDefaultAsync(t => t.Id == id);

            if (team == null)
                return false;

            _context.Teams.Remove(team);
            await _context.SaveChangesAsync();

            return true;
        }

        private static TeamDTO TeamToDTO(Team team) =>
            new TeamDTO
            {
                Id = team.Id,
                Name = team.Name
            };
    }
}
