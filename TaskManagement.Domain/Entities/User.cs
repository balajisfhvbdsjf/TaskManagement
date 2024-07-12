using System.Collections.Generic;

namespace TaskManagement.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Role { get; set; } // Employee, Manager, Admin
        public int TeamId { get; set; }
        public Team Team { get; set; }
        public ICollection<ETask> ETasks { get; set; }

        public User()
        {
            ETasks = new List<ETask>();
        }
    }
}
