using TaskManagement.Domain.Entities;

namespace TaskManagement.Domain.DTOs
{
    public class DocumentDTO
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public int TaskId { get; set; }
        public ETask ETask { get; set; }

    }
}
