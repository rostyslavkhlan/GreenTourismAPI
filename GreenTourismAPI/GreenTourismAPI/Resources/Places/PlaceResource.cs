using GreenTourismAPI.Resources.Hotels;
using GreenTourismAPI.Resources.Images;
using System.Collections.Generic;

namespace GreenTourismAPI.Resources.Places
{
    public class PlaceResource
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public string Thumbnail { get; set; }
        public IList<ImageResource> Images { get; set; }
        public IList<PreviewHotelResource> Hotels { get; set; }
    }
}
