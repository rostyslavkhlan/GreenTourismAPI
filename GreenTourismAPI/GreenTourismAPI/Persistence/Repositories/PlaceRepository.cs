using GreenTourismAPI.Domain.Models;
using GreenTourismAPI.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GreenTourismAPI.Persistence.Repositories
{
    public class PlaceRepository : BaseRepository, IPlaceRepository
    {
        public PlaceRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Place>> ListAsync()
        {
            return await context.Places.ToListAsync();
        }

        public async Task AddAsync(Place place)
        {
            await context.Places.AddAsync(place);
        }

        public async Task<Place> FindByIdAsync(int id)
        {
            return await context.Places.FindAsync(id);
        }

        public void Update(Place place)
        {
            context.Places.Update(place);
        }

        public void Remove(Place place)
        {
            context.Places.Remove(place);
        }
    }
}
