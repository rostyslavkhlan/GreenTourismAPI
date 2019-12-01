using GreenTourismAPI.Domain.Models;
using GreenTourismAPI.Domain.Services.Communication.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GreenTourismAPI.Domain.Services
{
    public interface IHotelService
    {
        Task<IEnumerable<Hotel>> ListAsync();
        Task<HotelResponse> SaveAsync(Hotel hotel);
        Task<HotelResponse> UpdateAsync(int id, Hotel hotel);
        Task<HotelResponse> DeleteAsync(int id);
    }
}
