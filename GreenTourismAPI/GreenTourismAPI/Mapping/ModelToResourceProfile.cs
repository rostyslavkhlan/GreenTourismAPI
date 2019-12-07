using AutoMapper;
using GreenTourismAPI.Domain.Models;
using GreenTourismAPI.Resources.Facilities;
using GreenTourismAPI.Resources.Hotels;
using GreenTourismAPI.Resources.Places;
using GreenTourismAPI.Resources.Rooms;

namespace GreenTourismAPI.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<Place, PlaceResource>();
            CreateMap<Place, PreviewPlaceResource>();

            CreateMap<Hotel, HotelResource>();
            CreateMap<Hotel, PreviewHotelResource>();

            CreateMap<Facility, FacilityResource>();

            CreateMap<Room, RoomResource>();
        }
    }
}
