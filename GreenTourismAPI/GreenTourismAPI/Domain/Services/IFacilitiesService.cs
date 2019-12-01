using GreenTourismAPI.Domain.Models;
using GreenTourismAPI.Domain.Services.Communication.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GreenTourismAPI.Domain.Services
{
    public interface IFacilityService
    {
        Task<IEnumerable<Facility>> ListAsync();
        Task<FacilityResponse> SaveAsync(Facility facility);
        Task<FacilityResponse> UpdateAsync(int id, Facility facility);
        Task<FacilityResponse> DeleteAsync(int id);
    }
}
