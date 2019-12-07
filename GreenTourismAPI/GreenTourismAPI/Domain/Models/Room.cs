using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace GreenTourismAPI.Domain.Models
{
    public class Room
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int PeopleCount { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        public string Thumbnail { get; set; }

        public int HotelId { get; set; }
        public Hotel Hotel { get; set; }

        //public IList<RoomFacility> RoomFacilities { get; set; }
    }
}
