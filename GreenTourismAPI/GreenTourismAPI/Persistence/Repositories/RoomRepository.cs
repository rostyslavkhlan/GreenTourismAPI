using GreenTourismAPI.Domain.Models;
using GreenTourismAPI.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GreenTourismAPI.Persistence.Repositories
{
    public class RoomRepository : BaseRepository, IRoomRepository
    {
        public RoomRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Room>> ListAsync()
        {
            return await context.Rooms
                .Include(r => r.RoomFacilities)
                .ThenInclude(ur => ur.Facility)
                .ToListAsync();
        }

        public async Task AddAsync(Room room)
        {
            await context.Rooms.AddAsync(room);
        }

        public async Task<Room> FindByIdAsync(int id)
        { 
            return await context.Rooms.SingleAsync(r => r.Id == id);
        }

        public void Update(Room room)
        {
            context.Rooms.Update(room);
        }

        public void Remove(Room room)
        {
            context.Rooms.Remove(room);
        }
    }
}
