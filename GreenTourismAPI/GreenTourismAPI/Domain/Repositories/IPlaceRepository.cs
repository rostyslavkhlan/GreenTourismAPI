using GreenTourismAPI.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GreenTourismAPI.Domain.Repositories
{
    public interface IPlaceRepository
    {
        Task<IEnumerable<Place>> ListAsync();
        Task AddAsync(Place place);
        Task<Place> FindByIdAsync(int id);
        void Update(Place place);
        void Remove(Place place);
    }
}
