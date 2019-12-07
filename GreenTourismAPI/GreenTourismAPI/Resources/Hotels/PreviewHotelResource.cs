using GreenTourismAPI.Resources.Places;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GreenTourismAPI.Resources.Hotels
{
    public class PreviewHotelResource
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Address { get; set; }
        public string ShortDescription { get; set; }
        public string Thumbnail { get; set; }
    }
}
