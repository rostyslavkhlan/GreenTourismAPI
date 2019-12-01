using GreenTourismAPI.Domain.Models;
using GreenTourismAPI.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GreenTourismAPI.Persistence.Repositories
{
    public class HotelRepository : BaseRepository, IHotelRepository
    {
        public HotelRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Hotel>> ListAsync()
        {
            return await context.Hotels.Include(h => h.Place).ToListAsync();
        }

        public async Task AddAsync(Hotel hotel)
        {
            await context.Hotels.AddAsync(hotel);
        }

        public async Task<Hotel> FindByIdAsync(int id)
        {
            return await context.Hotels.FindAsync(id);
        }

        public void Update(Hotel hotel)
        {
            context.Hotels.Update(hotel);
        }

        public void Remove(Hotel hotel)
        {
            context.Hotels.Remove(hotel);
        }
    }
}
