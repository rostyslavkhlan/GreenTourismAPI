using GreenTourismAPI.Domain.Models;

namespace GreenTourismAPI.Domain.Services.Communication.Responses
{
    public class HotelResponse : BaseResponse
    {
        public Hotel Hotel { get; private set; }

        public HotelResponse(bool success, string message, Hotel hotel) : base(success, message)
        {
            Hotel = hotel;
        }

        public HotelResponse(Hotel hotel) : this(true, string.Empty, hotel)
        { }

        public HotelResponse(string message) : this(false, message, null)
        { }
    }
}
