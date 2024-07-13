using System.Collections.Generic;
using System.Threading.Tasks;
using TaskManagement.Core.Interfaces;
using TaskManagement.Domain.DTOs;

namespace TaskManagement.Core.Services
{
    public class NoteService : INoteService
    {
        private readonly INoteRepository _noteRepository;

        public NoteService(INoteRepository noteRepository)
        {
            _noteRepository = noteRepository;
        }

        public async Task<IEnumerable<NoteDTO>> GetAllNotesAsync()
        {
            return await _noteRepository.GetAllNotesAsync();
        }

        public async Task<NoteDTO> GetNoteByIdAsync(int id)
        {
            return await _noteRepository.GetNoteByIdAsync(id);
        }

        public async Task<NoteDTO> CreateNoteAsync(NoteDTO noteDTO)
        {
            return await _noteRepository.CreateNoteAsync(noteDTO);
        }

        public async Task<NoteDTO> UpdateNoteAsync(int id, NoteDTO noteDTO)
        {
            return await _noteRepository.UpdateNoteAsync(id, noteDTO);
        }

        public async Task<bool> DeleteNoteAsync(int id)
        {
            return await _noteRepository.DeleteNoteAsync(id);
        }
    }
}
