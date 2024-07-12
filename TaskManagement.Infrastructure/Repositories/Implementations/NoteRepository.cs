using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskManagement.Core.Repositories.Interfaces;
using TaskManagement.Domain.Entities;
using TaskManagement.Infrastructure.Data;

namespace TaskManagement.Infrastructure.Repositories
{
    public class NoteRepository : INoteRepository
    {
        private readonly TaskManagementDbContext _dbContext;

        public NoteRepository(TaskManagementDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Note> GetNoteByIdAsync(int id)
        {
            return await _dbContext.Notes.FindAsync(id);
        }

        public async Task<IEnumerable<Note>> GetAllNotesAsync()
        {
            return await _dbContext.Notes.ToListAsync();
        }

        public async Task<Note> CreateNoteAsync(Note note)
        {
            _dbContext.Notes.Add(note);
            await _dbContext.SaveChangesAsync();
            return note;
        }

        public async Task<Note> UpdateNoteAsync(int id, Note note)
        {
            _dbContext.Entry(note).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return note;
        }

        public async Task<bool> DeleteNoteAsync(int id)
        {
            var note = await _dbContext.Notes.FindAsync(id);
            if (note == null)
                return false;

            _dbContext.Notes.Remove(note);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
