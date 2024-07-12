using System;
using System.Collections.Generic;
using System.Reflection.Metadata;

namespace TaskManagement.Domain.Entities
{
    public class Task
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public TaskStatus Status { get; set; }
        public DateTime DueDate { get; set; }
        public int AssignedUserId { get; set; }
        public User AssignedUser { get; set; }
        public ICollection<Document> Documents { get; set; }
        public ICollection<Note> Notes { get; set; }

        public Task()
        {
            Documents = new List<Document>();
            Notes = new List<Note>();
        }
    }
}
