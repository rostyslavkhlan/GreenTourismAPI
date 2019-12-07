using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GreenTourismAPI.Domain.Models;
using GreenTourismAPI.Domain.Services;
using GreenTourismAPI.Extensions;
using GreenTourismAPI.Resources.Rooms;
using Microsoft.AspNetCore.Mvc;

namespace GreenTourismAPI.Controllers
{
    [Route("api/[controller]")]
    public class RoomController : Controller
    {
        private readonly IRoomService _RoomService;
        private readonly IMapper _Mapper;

        public RoomController(IRoomService roomService, IMapper mapper)
        {
            _RoomService = roomService;
            _Mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<RoomResource>> GetAllAsync()
        {
            var rooms = await _RoomService.ListAsync();
            return _Mapper.Map<IEnumerable<Room>, IEnumerable<RoomResource>>(rooms);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveRoomResource roomResource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }

            var room = _Mapper.Map<SaveRoomResource, Room>(roomResource);
            var result = await _RoomService.SaveAsync(room);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            var roomResponse = _Mapper.Map<Room, RoomResource>(result.Room);
            return Ok(roomResponse);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveRoomResource roomResource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }

            var room = _Mapper.Map<SaveRoomResource, Room>(roomResource);
            var result = await _RoomService.UpdateAsync(id, room);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            var roomResponse = _Mapper.Map<Room, RoomResource>(result.Room);
            return Ok(roomResponse);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _RoomService.DeleteAsync(id);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            return Ok("Ok");
        }
    }
}
