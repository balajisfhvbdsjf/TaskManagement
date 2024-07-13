using System;
using TaskManagement.Domain.Enums;

namespace TaskManagement.Domain.DTOs
{
    public class ETaskDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public ETaskStatus Status { get; set; }
        public DateTime DueDate { get; set; }
        public int AssignedUserId { get; set; }
        public UserDTO AssignedUser { get; set; }
    }
}
