namespace GreenTourismAPI.Domain.Models
{
    public class Hotel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Place Place { get; set; }
    }
}
