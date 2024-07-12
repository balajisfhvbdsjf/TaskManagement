using System.Collections.Generic;
using System.Threading.Tasks;
using TaskManagement.Domain.Entities;

namespace TaskManagement.Core.Repositories.Interfaces
{
    public interface INoteRepository
    {
        Task<Note> GetNoteByIdAsync(int id);
        Task<IEnumerable<Note>> GetAllNotesAsync();
        Task<Note> CreateNoteAsync(Note note);
        Task<Note> UpdateNoteAsync(int id, Note note);
        Task<bool> DeleteNoteAsync(int id);
    }
}
