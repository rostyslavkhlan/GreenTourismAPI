using GreenTourismAPI.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GreenTourismAPI.Domain.Repositories
{
    public interface IRoomRepository
    {
        Task<IEnumerable<Room>> ListAsync();
        Task AddAsync(Room room);
        Task<Room> FindByIdAsync(int id);
        void Update(Room room);
        void Remove(Room room);
    }
}
