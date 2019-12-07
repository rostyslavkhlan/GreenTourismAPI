using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GreenTourismAPI.Domain.Models;
using GreenTourismAPI.Domain.Services;
using GreenTourismAPI.Extensions;
using GreenTourismAPI.Resources.Places;
using Microsoft.AspNetCore.Mvc;

namespace GreenTourismAPI.Controllers
{
    [Route("api/[controller]")]
    public class PlacesController : ControllerBase
    {
        private readonly IPlaceService _PlaceService;
        private readonly IMapper _Mapper;

        public PlacesController(IPlaceService placeService, IMapper mapper)
        {
            _PlaceService = placeService;
            _Mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<PreviewPlaceResource>> GetAllAsync()
        {
            var places = await _PlaceService.GetAllAsync();
            var result = _Mapper.Map<IEnumerable<Place>, IEnumerable<PreviewPlaceResource>>(places).ToList();
            result.ToList().ForEach(p => p.Thumbnail = Request.Host.ToString() + "/" + p.Thumbnail);

            return result;
        }

        [HttpGet("{id}")]
        public async Task<PlaceResource> GetByIdAsync(int id)
        {
            var place = await _PlaceService.GetByIdAsync(id);
            var result = _Mapper.Map<Place, PlaceResource>(place);
            result.Images.ToList().ForEach(i => i.Name = Request.Host.ToString() + "/" + i.Name);
            result.Thumbnail = Request.Host.ToString() + "/" + result.Thumbnail;

            return result;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SavePlaceResource placeResource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }

            var place = _Mapper.Map<SavePlaceResource, Place>(placeResource);
            var result = await _PlaceService.SaveAsync(place);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            var placeResponse = _Mapper.Map<Place, PlaceResource>(result.Place);
            return Ok(placeResponse);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SavePlaceResource placeResource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }

            var place = _Mapper.Map<SavePlaceResource, Place>(placeResource);
            var result = await _PlaceService.UpdateAsync(id, place);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            var placeResponse = _Mapper.Map<Place, PlaceResource>(result.Place);
            return Ok(placeResponse);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _PlaceService.DeleteAsync(id);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            return Ok("Ok");
        }
    }
}
