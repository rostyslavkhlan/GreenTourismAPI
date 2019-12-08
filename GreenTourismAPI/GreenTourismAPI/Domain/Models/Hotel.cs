using System.Collections.Generic;

namespace GreenTourismAPI.Domain.Models
{
    public class Hotel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Address { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public string Thumbnail { get; set; }
        public IList<HotelImage> Images { get; set; } = new List<HotelImage>();
        public IList<Room> Rooms { get; set; } = new List<Room>();

        public int PlaceId { get; set; }
        public Place Place { get; set; }
    }
}
