using GreenTourismAPI.Domain.Models;
using GreenTourismAPI.Domain.Repositories;
using GreenTourismAPI.Domain.Services;
using GreenTourismAPI.Domain.Services.Communication.Responses;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GreenTourismAPI.Services
{
    public class PlaceService : IPlaceService
    {
        private readonly IPlaceRepository _PlaceRepository;
        private readonly IUnitOfWork _UnitOfWork;

        public PlaceService(IPlaceRepository placeRepository, IUnitOfWork unitOfWork)
        {
            _PlaceRepository = placeRepository;
            _UnitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Place>> ListAsync()
        {
            return await _PlaceRepository.ListAsync();
        }

        public async Task<PlaceResponse> SaveAsync(Place place)
        {
            try
            {
                await _PlaceRepository.AddAsync(place);
                await _UnitOfWork.CompleteAsync();

                return new PlaceResponse(place);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new PlaceResponse($"An error occurred when saving the place: {ex.Message}");
            }
        }

        public async Task<PlaceResponse> UpdateAsync(int id, Place place)
        {
            var existingPlace = await _PlaceRepository.FindByIdAsync(id);

            if (existingPlace == null)
            {
                return new PlaceResponse("Place not found.");
            }

            existingPlace.Title = place.Title;
            existingPlace.ShortDescription = place.ShortDescription;
            existingPlace.LongDescription = place.LongDescription;
            existingPlace.Thumbnail = place.Thumbnail;

            try
            {
                _PlaceRepository.Update(existingPlace);
                await _UnitOfWork.CompleteAsync();

                return new PlaceResponse(existingPlace);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new PlaceResponse($"An error occurred when updating the place: {ex.Message}");
            }
        }

        public async Task<PlaceResponse> DeleteAsync(int id)
        {
            var existingPlace = await _PlaceRepository.FindByIdAsync(id);

            if (existingPlace == null)
            {
                return new PlaceResponse("Place not found.");
            }

            try
            {
                _PlaceRepository.Remove(existingPlace);
                await _UnitOfWork.CompleteAsync();

                return new PlaceResponse(existingPlace);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new PlaceResponse($"An error occurred when deleting the place: {ex.Message}");
            }
        }
    }
}
