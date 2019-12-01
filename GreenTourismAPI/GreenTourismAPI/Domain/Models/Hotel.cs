namespace GreenTourismAPI.Domain.Models
{
    public class Hotel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Address { get; set; }
        public string ShortDescription { get; set; }
        public string Thumbnail { get; set; }

        public int PlaceId { get; set; }
        public Place Place { get; set; }
    }
}
