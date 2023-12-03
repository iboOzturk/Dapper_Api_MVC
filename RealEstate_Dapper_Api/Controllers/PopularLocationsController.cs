using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.DTOs.PopularLocationDtos;
using RealEstate_Dapper_Api.Repositories.PopularLocationRepositories;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PopularLocationsController : ControllerBase
    {
        private readonly IPopularLocationRepository _locationRepository;

        public PopularLocationsController(IPopularLocationRepository locationRepository)
        {
            _locationRepository = locationRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllPopularLocationAsync()
        {
            var values = await _locationRepository.GetAllPopularLocationAsync();
            return Ok(values.ToList());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPopularLocation(int id)
        {
            var value = await _locationRepository.GetByIdPopularLocationAsync(id);
            return Ok(value);
        }
        [HttpPost]
        public IActionResult CreatePopularLocation(CreatePopularLocationDto createPopularLocationDto)
        {
             _locationRepository.CreatePopularLocationAsync(createPopularLocationDto);
            return Ok("Başarılı Şekilde Eklendi");
        }
        [HttpPut]
        public IActionResult UpdatePopularLocation(UpdatePopularLocationDto updatePopularLocationDto)
        {
            _locationRepository.UpdatePopularLocationAsync(updatePopularLocationDto);
            return Ok("Başarılı Şekilde Güncellendi");
        }
        [HttpDelete("{id}")]
        public IActionResult DeletePopularLocation(int id)
        {
            _locationRepository.DeletePopularLocationAsync(id);
            return Ok("Başarılı Şekilde Silindi");
        }
    }
}
