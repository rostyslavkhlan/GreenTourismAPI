using GreenTourismAPI.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GreenTourismAPI.Domain.Repositories
{
    public interface IHotelRepository
    {
        Task<IEnumerable<Hotel>> GetAllAsync();
        Task AddAsync(Hotel hotel);
        Task<Hotel> FindByIdAsync(int id);
        void Update(Hotel hotel);
        void Remove(Hotel hotel);
    }
}
