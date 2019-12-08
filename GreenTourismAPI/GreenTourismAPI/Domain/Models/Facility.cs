using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace GreenTourismAPI.Domain.Models
{
    public class Facility
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<RoomFacility> RoomsFacility { get; set; } = new Collection<RoomFacility>();

    }
}
