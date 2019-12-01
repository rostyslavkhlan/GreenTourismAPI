using System.ComponentModel.DataAnnotations;

namespace GreenTourismAPI.Resources.Places
{
    public class SavePlaceResource
    {
        [Required]
        [MaxLength(50)]
        public string Title { get; set; }

        [Required]
        [MaxLength(200)]
        public string ShortDescription { get; set; }

        [Required]
        public string LongDescription { get; set; }

        [Required]
        public string Thumbnail { get; set; }
    }
}
