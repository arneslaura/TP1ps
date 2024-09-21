using System;

namespace Domain.Entities
{
    public class User
    {
        public int UserID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public List<Tasks> Tasks { get; set; }
    }
}
