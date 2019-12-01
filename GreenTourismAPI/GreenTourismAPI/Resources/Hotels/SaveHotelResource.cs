using GreenTourismAPI.Resources.Places;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GreenTourismAPI.Resources.Hotels
{
    public class SaveHotelResource
    {
        [Required]
        [MaxLength(50)]
        public string Title { get; set; }

        [Required]
        [MaxLength(50)]
        public string Address { get; set; }

        [Required]
        public string ShortDescription { get; set; }

        [Required]
        public string Thumbnail { get; set; }

        [Required]
        public string PlaceId { get; set; }
    }
}
