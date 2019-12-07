using GreenTourismAPI.Domain.Models;
using GreenTourismAPI.Domain.Services.Communication.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GreenTourismAPI.Domain.Services
{
    public interface IRoomService
    {
        Task<IEnumerable<Room>> ListAsync();
        Task<RoomResponse> SaveAsync(Room room);
        Task<RoomResponse> UpdateAsync(int id, Room room);
        Task<RoomResponse> DeleteAsync(int id);
    }
}
