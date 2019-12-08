using System.ComponentModel.DataAnnotations.Schema;

namespace GreenTourismAPI.Domain.Models
{
    [Table("RoomFacilities")]
    public class RoomFacility
    {
        public int RoomId { get; set; }
        public Room Room { get; set; }

        public int FacilityId { get; set; }
        public Facility Facility { get; set; }
    }
}
