using AutoMapper;
using GreenTourismAPI.Domain.Models;
using GreenTourismAPI.Resources.Hotels;
using GreenTourismAPI.Resources.Places;

namespace GreenTourismAPI.Mapping
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<SavePlaceResource, Place>();
            CreateMap<SaveHotelResource, Hotel>();
        }
    }
}
