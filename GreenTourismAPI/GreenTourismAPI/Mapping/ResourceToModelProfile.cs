using AutoMapper;
using GreenTourismAPI.Domain.Models;
using GreenTourismAPI.Resources.Facilities;
using GreenTourismAPI.Resources.Hotels;
using GreenTourismAPI.Resources.Places;
using GreenTourismAPI.Resources.Rooms;
using GreenTourismAPI.Resources.Users;

namespace GreenTourismAPI.Mapping
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<SavePlaceResource, Place>();
            CreateMap<SaveHotelResource, Hotel>();
            CreateMap<SaveFacilityResource, Facility>();
            CreateMap<SaveRoomResource, Room>();
            CreateMap<UserCredentialsResource, User>();
            CreateMap<UserRegisterResource, User>();
        }
    }
}
