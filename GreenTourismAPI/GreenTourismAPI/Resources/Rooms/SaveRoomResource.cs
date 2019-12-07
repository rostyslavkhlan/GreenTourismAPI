using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GreenTourismAPI.Resources.Rooms
{
    public class SaveRoomResource
    {
        [Required]
        [MaxLength(50)]
        public string Title { get; set; }

        [Required]
        public int PeopleCount { get; set; }

        [Required]
        public int Price { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Thumbnail { get; set; }

        [Required]
        public string HotelId { get; set; }
        //public IList<string> FacilitiesIds { get; set; }
    }
}
