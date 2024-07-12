using System.Collections.Generic;
using System.Threading.Tasks;
using TaskManagement.Core.Repositories.Interfaces;
using TaskManagement.Core.Services.Interfaces;
using TaskManagement.Domain.Entities;

namespace TaskManagement.Core.Services
{
    public class NoteService : INoteService
    {
        private readonly INoteRepository _noteRepository;

        public NoteService(INoteRepository noteRepository)
        {
            _noteRepository = noteRepository;
        }

        public async Task<Note> GetNoteByIdAsync(int id)
        {
            return await _noteRepository.GetNoteByIdAsync(id);
        }

        public async Task<IEnumerable<Note>> GetAllNotesAsync()
        {
            return await _noteRepository.GetAllNotesAsync();
        }

        public async Task<Note> CreateNoteAsync(Note note)
        {
            return await _noteRepository.CreateNoteAsync(note);
        }

        public async Task<Note> UpdateNoteAsync(int id, Note note)
        {
            return await _noteRepository.UpdateNoteAsync(id, note);
        }

        public async Task<bool> DeleteNoteAsync(int id)
        {
            return await _noteRepository.DeleteNoteAsync(id);
        }
    }
}
