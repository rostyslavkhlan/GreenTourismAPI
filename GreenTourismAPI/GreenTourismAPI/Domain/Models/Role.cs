using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace GreenTourismAPI.Domain.Models
{
    public class Role
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<UserRole> UsersRole { get; set; } = new Collection<UserRole>();
    }
}
