using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GreenTourismAPI.Resources.Places
{
    public class PlaceResource
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public string Thumbnail { get; set; }
    }
}
