using GreenTourismAPI.Domain.Models;
using GreenTourismAPI.Domain.Repositories;
using GreenTourismAPI.Domain.Services;
using GreenTourismAPI.Domain.Services.Communication.Responses;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GreenTourismAPI.Services
{
    public class HotelService : IHotelService
    {
        private readonly IHotelRepository _HotelRepository;
        private readonly IPlaceRepository _PlaceRepository;
        private readonly IUnitOfWork _UnitOfWork;

        public HotelService(IHotelRepository hotelRepository, IPlaceRepository placeRepository, IUnitOfWork unitOfWork)
        {
            _HotelRepository = hotelRepository;
            _PlaceRepository = placeRepository;
            _UnitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Hotel>> GetAllAsync()
        {
            return await _HotelRepository.GetAllAsync();
        }

        public async Task<Hotel> GetByIdAsync(int id)
        {
            return await _HotelRepository.FindByIdAsync(id);
        }

        public async Task<HotelResponse> SaveAsync(Hotel hotel)
        {
            var existingPlace = await _PlaceRepository.FindByIdAsync(hotel.PlaceId);

            if (existingPlace == null)
            {
                return new HotelResponse($"Place with id {hotel.PlaceId} not found.");
            }

            hotel.Place = existingPlace;

            try
            {
                await _HotelRepository.AddAsync(hotel);
                await _UnitOfWork.CompleteAsync();

                return new HotelResponse(hotel);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new HotelResponse($"An error occurred when saving the hotel: {ex.Message}");
            }
        }

        public async Task<HotelResponse> UpdateAsync(int id, Hotel hotel)
        {
            var existingHotel = await _HotelRepository.FindByIdAsync(id);

            if (existingHotel == null)
            {
                return new HotelResponse("Hotel not found.");
            }

            var existingPlace = await _PlaceRepository.FindByIdAsync(hotel.PlaceId);

            if (existingPlace == null)
            {
                return new HotelResponse($"Place with id {hotel.PlaceId} not found.");
            }

            existingHotel.Title = hotel.Title;
            existingHotel.Address = hotel.Address;
            existingHotel.ShortDescription = hotel.ShortDescription;
            existingHotel.Thumbnail = hotel.Thumbnail;
            existingHotel.PlaceId = hotel.PlaceId;
            existingHotel.Place = existingPlace;

            try
            {
                _HotelRepository.Update(existingHotel);
                await _UnitOfWork.CompleteAsync();

                return new HotelResponse(existingHotel);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new HotelResponse($"An error occurred when updating the hotel: {ex.Message}");
            }
        }

        public async Task<HotelResponse> DeleteAsync(int id)
        {
            var existingHotel = await _HotelRepository.FindByIdAsync(id);

            if (existingHotel == null)
            {
                return new HotelResponse("Hotel not found.");
            }

            try
            {
                _HotelRepository.Remove(existingHotel);
                await _UnitOfWork.CompleteAsync();

                return new HotelResponse(existingHotel);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new HotelResponse($"An error occurred when deleting the hotel: {ex.Message}");
            }
        }
    }
}
