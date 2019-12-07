using AutoMapper;
using GreenTourismAPI.Domain.Models;
using GreenTourismAPI.Resources.Facilities;
using GreenTourismAPI.Resources.Hotels;
using GreenTourismAPI.Resources.Images;
using GreenTourismAPI.Resources.Places;
using GreenTourismAPI.Resources.Rooms;

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

            CreateMap<Hotel, HotelResource>();
            CreateMap<Hotel, PreviewHotelResource>();

            CreateMap<Facility, FacilityResource>();

            CreateMap<Room, RoomResource>();

            CreateMap<PlaceImage, ImageResource>()
                .ForMember(nameof(PlaceImage.Name), opt => opt.MapFrom(i => "Images/Places/" + i.PlaceId.ToString() + "/" + i.Name));
        }
    }
}
