using AutoMapper;
using GreenTourismAPI.Domain.Models;
using GreenTourismAPI.Domain.Services;
using GreenTourismAPI.Extensions;
using GreenTourismAPI.Resources.Hotels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GreenTourismAPI.Controllers
{
    [Route("api/[controller]")]
    public class HotelsController : ControllerBase
    {
        private readonly IHotelService _HotelService;
        private readonly IMapper _Mapper;

        public HotelsController(IHotelService hotelService, IMapper mapper)
        {
            _HotelService = hotelService;
            _Mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<PreviewHotelResource>> GetAllAsync()
        {
            var hotels = await _HotelService.GetAllAsync();
            var result = _Mapper.Map<IEnumerable<Hotel>, IEnumerable<PreviewHotelResource>>(hotels).ToList();
            result.ToList().ForEach(h => h.Thumbnail = Request.Host.ToString() + "/" + h.Thumbnail);

            return result;
        }

        [HttpGet("{id}")]
        public async Task<HotelResource> GetByIdAsync(int id)
        {
            var hotel = await _HotelService.GetByIdAsync(id);
            var result = _Mapper.Map<Hotel, HotelResource>(hotel);
            result.Images.ToList().ForEach(i => i.Name = Request.Host.ToString() + "/" + i.Name);
            result.Thumbnail = Request.Host.ToString() + "/" + result.Thumbnail;

            return result;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveHotelResource hotelResource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }

            var hotel = _Mapper.Map<SaveHotelResource, Hotel>(hotelResource);
            var result = await _HotelService.SaveAsync(hotel);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            var hotelResponse = _Mapper.Map<Hotel, HotelResource>(result.Hotel);
            return Ok(hotelResponse);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveHotelResource hotelResource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }

            var hotel = _Mapper.Map<SaveHotelResource, Hotel>(hotelResource);
            var result = await _HotelService.UpdateAsync(id, hotel);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            var hotelResponse = _Mapper.Map<Hotel, HotelResource>(result.Hotel);
            return Ok(hotelResponse);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _HotelService.DeleteAsync(id);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            return Ok("Ok");
        }
    }
}
