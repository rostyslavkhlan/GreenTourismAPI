using AutoMapper;
using GreenTourismAPI.Domain.Models;
using GreenTourismAPI.Resources.Places;

namespace GreenTourismAPI.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<Place, PlaceResource>();
            CreateMap<Place, PlacePreviewResource>();
        }
    }
}
