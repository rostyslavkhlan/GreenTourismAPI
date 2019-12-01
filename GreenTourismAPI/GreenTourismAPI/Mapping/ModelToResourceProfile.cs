using AutoMapper;
using GreenTourismAPI.Domain.Models;
using GreenTourismAPI.Resources.Hotels;
using GreenTourismAPI.Resources.Places;

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
        }
    }
}
