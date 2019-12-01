using GreenTourismAPI.Domain.Models;
using GreenTourismAPI.Domain.Services.Communication.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GreenTourismAPI.Domain.Services
{
    public interface IPlaceService
    {
        Task<IEnumerable<Place>> ListAsync();
        Task<PlaceResponse> SaveAsync(Place place);
        Task<PlaceResponse> UpdateAsync(int id, Place place);
        Task<PlaceResponse> DeleteAsync(int id);
    }
}
