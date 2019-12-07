namespace GreenTourismAPI.Domain.Models
{
    public abstract class BaseImage
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class PlaceImage : BaseImage
    {
        public int PlaceId { get; set; }
    }

    public class HotelImage : BaseImage
    {
        public int HotelId { get; set; }
    }
}
