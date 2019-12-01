using GreenTourismAPI.Domain.Models;

namespace GreenTourismAPI.Domain.Services.Communication.Responses
{
    public class FacilityResponse : BaseResponse
    {
        public Facility Facility { get; private set; }

        public FacilityResponse(bool success, string message, Facility facility) : base(success, message)
        {
            Facility = facility;
        }

        public FacilityResponse(Facility facility) : this(true, string.Empty, facility)
        { }

        public FacilityResponse(string message) : this(false, message, null)
        { }
    }
}
