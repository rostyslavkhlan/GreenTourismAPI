using GreenTourismAPI.Domain.Models;
using GreenTourismAPI.Domain.Repositories;
using GreenTourismAPI.Domain.Services;
using GreenTourismAPI.Domain.Services.Communication.Responses;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GreenTourismAPI.Services
{
    public class RoomService : IRoomService
    {
        private readonly IRoomRepository _RoomRepository;
        private readonly IHotelRepository _HotelRepository;
        private readonly IUnitOfWork _UnitOfWork;

        public RoomService(IRoomRepository roomRepository,
                            IHotelRepository hotelRepository, IUnitOfWork unitOfWork)
        {
            _RoomRepository = roomRepository;
            _HotelRepository = hotelRepository;
            _UnitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Room>> ListAsync()
        {
            return await _RoomRepository.ListAsync();
        }

        public async Task<RoomResponse> SaveAsync(Room room)
        {
            try
            {
                await _RoomRepository.AddAsync(room);
                await _UnitOfWork.CompleteAsync();

                return new RoomResponse(room);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new RoomResponse($"An error occurred when saving the room: {ex.Message}");
            }
        }

        public async Task<RoomResponse> UpdateAsync(int id, Room room)
        {
            var existingRoom = await _RoomRepository.FindByIdAsync(id);

            if (existingRoom == null)
            {
                return new RoomResponse("Room not found.");
            }

            var existingHotel = await _HotelRepository.FindByIdAsync(room.HotelId);

            if (existingHotel == null)
            {
                return new RoomResponse($"Hotel with id {room.HotelId} not found.");
            }

            //var facilities = (await _FacilityRepository.ListAsync()).Where(f => room.RoomFacilities.Select(i => i.FacilityId).Contains(f.Id)).ToList();

            existingRoom.Title = room.Title;
            existingRoom.PeopleCount = room.PeopleCount;
            existingRoom.Price = room.Price;
            existingRoom.Description = room.Description;
            existingRoom.Thumbnail = room.Thumbnail;

            existingRoom.HotelId = existingHotel.Id;
            existingRoom.Hotel = existingHotel;

            //existingRoom.Аф = facilities.Select(f => f.Id).ToList();
            //existingRoom.RoomFacilities = facilities;

            try
            {
                _RoomRepository.Update(existingRoom);
                await _UnitOfWork.CompleteAsync();

                return new RoomResponse(existingRoom);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new RoomResponse($"An error occurred when updating the room: {ex.Message}");
            }
        }

        public async Task<RoomResponse> DeleteAsync(int id)
        {
            var existingRoom = await _RoomRepository.FindByIdAsync(id);

            if (existingRoom == null)
            {
                return new RoomResponse("Room not found.");
            }

            try
            {
                _RoomRepository.Remove(existingRoom);
                await _UnitOfWork.CompleteAsync();

                return new RoomResponse(existingRoom);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new RoomResponse($"An error occurred when deleting the room: {ex.Message}");
            }
        }
    }
}
