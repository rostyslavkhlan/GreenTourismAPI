using GreenTourismAPI.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GreenTourismAPI.Domain.Repositories
{
    public interface IFacilityRepository
    {
        Task<IEnumerable<Facility>> ListAsync();
        Task AddAsync(Facility facility);
        Task<Facility> FindByIdAsync(int id);
        void Update(Facility facility);
        void Remove(Facility facility);
    }
}
