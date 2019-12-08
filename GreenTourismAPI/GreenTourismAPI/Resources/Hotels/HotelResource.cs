using GreenTourismAPI.Resources.Images;
using GreenTourismAPI.Resources.Rooms;
using System.Collections.Generic;

namespace GreenTourismAPI.Resources.Hotels
{
    public class HotelResource
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Address { get; set; }
        public string ShortDescription { get; set; }
        public string Thumbnail { get; set; }
        public IList<ImageResource> Images { get; set; }
        //public IList<RoomResource> Rooms { get; set; }
    }
}
