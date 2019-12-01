using GreenTourismAPI.Domain.Models;

namespace GreenTourismAPI.Domain.Services.Communication.Responses
{
    public class PlaceResponse : BaseResponse
    {
        public Place Place { get; private set; }

        private PlaceResponse(bool success, string message, Place place) : base(success, message)
        {
            Place = place;
        }

        public PlaceResponse(Place place) : this(true, string.Empty, place)
        { }

        public PlaceResponse(string message) : this(false, message, null)
        { }
    }
}
