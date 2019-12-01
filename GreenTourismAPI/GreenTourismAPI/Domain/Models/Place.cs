using System.Collections;
using System.Collections.Generic;

namespace GreenTourismAPI.Domain.Models
{
    public class Place
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public string Thumbnail { get; set; }

        public IList<Hotel> Hotels { get; set; } = new List<Hotel>();
    }
}