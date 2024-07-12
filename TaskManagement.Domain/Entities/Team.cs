using System.Collections.Generic;

namespace TaskManagement.Domain.Entities
{
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<User> Users { get; set; }

        public Team()
        {
            Users = new List<User>();
        }
    }
}
