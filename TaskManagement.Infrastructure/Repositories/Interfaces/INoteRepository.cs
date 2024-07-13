using System.Collections.Generic;
using System.Threading.Tasks;
using TaskManagement.Domain.DTOs;

namespace TaskManagement.Core.Interfaces
{
    public interface INoteRepository
    {
        Task<IEnumerable<NoteDTO>> GetAllNotesAsync();
        Task<NoteDTO> GetNoteByIdAsync(int id);
        Task<NoteDTO> CreateNoteAsync(NoteDTO noteDTO);
        Task<NoteDTO> UpdateNoteAsync(int id, NoteDTO noteDTO);
        Task<bool> DeleteNoteAsync(int id);
    }
}
