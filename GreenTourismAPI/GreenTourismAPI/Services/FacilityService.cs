using GreenTourismAPI.Domain.Models;
using GreenTourismAPI.Domain.Repositories;
using GreenTourismAPI.Domain.Services;
using GreenTourismAPI.Domain.Services.Communication.Responses;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GreenTourismAPI.Services
{
    public class FacilityService : IFacilityService
    {
        private readonly IFacilityRepository _FacilityRepository;
        private readonly IUnitOfWork _UnitOfWork;

        public FacilityService(IFacilityRepository facilityRepository, IUnitOfWork unitOfWork)
        {
            _FacilityRepository = facilityRepository;
            _UnitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Facility>> ListAsync()
        {
            return await _FacilityRepository.ListAsync();
        }

        public async Task<FacilityResponse> SaveAsync(Facility facility)
        {
            try
            {
                await _FacilityRepository.AddAsync(facility);
                await _UnitOfWork.CompleteAsync();

                return new FacilityResponse(facility);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new FacilityResponse($"An error occurred when saving the facility: {ex.Message}");
            }
        }

        public async Task<FacilityResponse> UpdateAsync(int id, Facility facility)
        {
            var existingFacility = await _FacilityRepository.FindByIdAsync(id);

            if (existingFacility == null)
            {
                return new FacilityResponse("Facility not found.");
            }

            existingFacility.Name = facility.Name;

            try
            {
                _FacilityRepository.Update(existingFacility);
                await _UnitOfWork.CompleteAsync();

                return new FacilityResponse(existingFacility);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new FacilityResponse($"An error occurred when updating the facility: {ex.Message}");
            }
        }

        public async Task<FacilityResponse> DeleteAsync(int id)
        {
            var existingFacility = await _FacilityRepository.FindByIdAsync(id);

            if (existingFacility == null)
            {
                return new FacilityResponse("Facility not found.");
            }

            try
            {
                _FacilityRepository.Remove(existingFacility);
                await _UnitOfWork.CompleteAsync();

                return new FacilityResponse(existingFacility);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new FacilityResponse($"An error occurred when deleting the facility: {ex.Message}");
            }
        }
    }
}
