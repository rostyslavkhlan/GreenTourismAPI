using AutoMapper;
using GreenTourismAPI.Domain.Models;
using GreenTourismAPI.Domain.Security.Tokens;
using GreenTourismAPI.Resources.Facilities;
using GreenTourismAPI.Resources.Hotels;
using GreenTourismAPI.Resources.Images;
using GreenTourismAPI.Resources.Places;
using GreenTourismAPI.Resources.Rooms;
using GreenTourismAPI.Resources.Users;
using System.Linq;

namespace GreenTourismAPI.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<Place, PlaceResource>()
                .ForMember(nameof(Place.Thumbnail), opt => opt.MapFrom(i => "Images/Places/" + i.Id.ToString() + "/" + i.Thumbnail));
            CreateMap<Place, PreviewPlaceResource>()
                .ForMember(nameof(Place.Thumbnail), opt => opt.MapFrom(i => "Images/Places/" + i.Id.ToString() + "/" + i.Thumbnail));

            CreateMap<Hotel, HotelResource>()
                .ForMember(nameof(Hotel.Thumbnail), opt => opt.MapFrom(i => "Images/Hotels/" + i.Id.ToString() + "/" + i.Thumbnail));
            CreateMap<Hotel, PreviewHotelResource>()
                .ForMember(nameof(Hotel.Thumbnail), opt => opt.MapFrom(i => "Images/Hotels/" + i.Id.ToString() + "/" + i.Thumbnail));

            CreateMap<Facility, FacilityResource>();

            CreateMap<Room, RoomResource>();

            CreateMap<PlaceImage, ImageResource>()
                .ForMember(nameof(BaseImage.Name), opt => opt.MapFrom(i => "Images/Places/" + i.PlaceId.ToString() + "/" + i.Name));
            CreateMap<HotelImage, ImageResource>()
                .ForMember(nameof(BaseImage.Name), opt => opt.MapFrom(i => "Images/Hotels/" + i.HotelId.ToString() + "/" + i.Name));

            CreateMap<User, UserResource>()
                .ForMember(u => u.Roles, opt => opt.MapFrom(u => u.UserRoles.Select(ur => ur.Role.Name)));

            CreateMap<AccessToken, AccessTokenResource>()
                .ForMember(a => a.AccessToken, opt => opt.MapFrom(a => a.Token))
                .ForMember(a => a.RefreshToken, opt => opt.MapFrom(a => a.RefreshToken.Token))
                .ForMember(a => a.Expiration, opt => opt.MapFrom(a => a.Expiration));
        }
    }
}
