using GreenTourismAPI.Domain.Models;
using GreenTourismAPI.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GreenTourismAPI.Persistence.Repositories
{
    public class FacilityRepository : BaseRepository, IFacilityRepository
    {
        public FacilityRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Facility>> ListAsync()
        {
            return await context.Facilities.ToListAsync();
        }

        public async Task AddAsync(Facility facility)
        {
            await context.Facilities.AddAsync(facility);
        }

        public async Task<Facility> FindByIdAsync(int id)
        {
            return await context.Facilities.FindAsync(id);
        }

        public void Update(Facility facility)
        {
            context.Facilities.Update(facility);
        }

        public void Remove(Facility facility)
        {
            context.Facilities.Remove(facility);
        }
    }
}
