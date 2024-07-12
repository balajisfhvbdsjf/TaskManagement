using System;

namespace TaskManagement.Domain.Entities
{
    public class Document
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public DateTime UploadedAt { get; set; }
        public int TaskId { get; set; }
        public ETask ETask { get; set; }
    }
}
