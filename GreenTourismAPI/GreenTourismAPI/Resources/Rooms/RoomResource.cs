using GreenTourismAPI.Domain.Models;
using System.Collections.Generic;

namespace GreenTourismAPI.Resources.Rooms
{
    public class RoomResource
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int PeopleCount { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        public string Thumbnail { get; set; }

        public IList<string> Facilities { get; set; }
    }
}
