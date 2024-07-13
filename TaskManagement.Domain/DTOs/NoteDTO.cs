using TaskManagement.Domain.Entities;

namespace TaskManagement.Domain.DTOs
{
    public class NoteDTO
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int TaskId { get; set; }
        public ETask ETask { get; set; }

    }
}
