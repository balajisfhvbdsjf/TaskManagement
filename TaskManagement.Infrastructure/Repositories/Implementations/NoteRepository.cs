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
    public class NoteRepository : INoteRepository
    {
        private readonly TaskManagementDbContext _context;

        public NoteRepository(TaskManagementDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<NoteDTO>> GetAllNotesAsync()
        {
            var notes = await _context.Notes
                .Include(n => n.ETask)
                .Select(n => NoteToDTO(n))
                .ToListAsync();

            return notes;
        }

        public async Task<NoteDTO> GetNoteByIdAsync(int id)
        {
            var note = await _context.Notes
                .Include(n => n.ETask)
                .FirstOrDefaultAsync(n => n.Id == id);

            return NoteToDTO(note);
        }

        public async Task<NoteDTO> CreateNoteAsync(NoteDTO noteDTO)
        {
            var note = new Note
            {
                Content = noteDTO.Content,
                TaskId = noteDTO.TaskId
            };

            _context.Notes.Add(note);
            await _context.SaveChangesAsync();

            return NoteToDTO(note);
        }

        public async Task<NoteDTO> UpdateNoteAsync(int id, NoteDTO noteDTO)
        {
            var note = await _context.Notes.FirstOrDefaultAsync(n => n.Id == id);

            if (note == null)
                throw new Exception($"Note with id {id} not found");

            note.Content = noteDTO.Content;
            note.TaskId = noteDTO.TaskId;

            await _context.SaveChangesAsync();

            return NoteToDTO(note);
        }

        public async Task<bool> DeleteNoteAsync(int id)
        {
            var note = await _context.Notes.FirstOrDefaultAsync(n => n.Id == id);

            if (note == null)
                return false;

            _context.Notes.Remove(note);
            await _context.SaveChangesAsync();

            return true;
        }

        private static NoteDTO NoteToDTO(Note note) =>
            new NoteDTO
            {
                Id = note.Id,
                Content = note.Content,
                TaskId = note.TaskId,
                ETask = TaskRepository.TaskToDTO(note.ETask)
            };
    }
}
