using TaskManagement.Domain.Entities;

namespace TaskManagement.Core.Services.Interfaces
{
    public interface INoteService
    {
        Task<Note> GetNoteByIdAsync(int id);
        Task<IEnumerable<Note>> GetAllNotesAsync();
        Task<Note> CreateNoteAsync(Note note);
        Task<Note> UpdateNoteAsync(int id, Note note);
        Task<bool> DeleteNoteAsync(int id);
    }
}
