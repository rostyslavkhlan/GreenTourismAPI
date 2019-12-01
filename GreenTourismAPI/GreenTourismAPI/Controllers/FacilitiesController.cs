using AutoMapper;
using GreenTourismAPI.Domain.Models;
using GreenTourismAPI.Domain.Services;
using GreenTourismAPI.Extensions;
using GreenTourismAPI.Resources.Facilities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GreenTourismAPI.Controllers
{
    [Route("api/[controller]")]
    public class FacilitiesController : ControllerBase
    {
        private readonly IFacilityService _FacilitiesService;
        private readonly IMapper _Mapper;

        public FacilitiesController(IFacilityService FacilitiesService, IMapper mapper)
        {
            _FacilitiesService = FacilitiesService;
            _Mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<FacilityResource>> GetAllAsync()
        {
            var facilities = await _FacilitiesService.ListAsync();
            return _Mapper.Map<IEnumerable<Facility>, IEnumerable<FacilityResource>>(facilities);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveFacilityResource facilityResource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }

            var facility = _Mapper.Map<SaveFacilityResource, Facility>(facilityResource);
            var result = await _FacilitiesService.SaveAsync(facility);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            var facilityResponse = _Mapper.Map<Facility, FacilityResource>(result.Facility);
            return Ok(facilityResponse);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveFacilityResource facilityResource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }

            var facility = _Mapper.Map<SaveFacilityResource, Facility>(facilityResource);
            var result = await _FacilitiesService.UpdateAsync(id, facility);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            var FacilitiesResponse = _Mapper.Map<Facility, FacilityResource>(result.Facility);
            return Ok(FacilitiesResponse);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _FacilitiesService.DeleteAsync(id);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            return Ok("Ok");
        }
    }
}
