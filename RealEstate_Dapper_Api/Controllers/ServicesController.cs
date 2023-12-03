using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.DTOs.ServiceDtos;
using RealEstate_Dapper_Api.DTOs.WhoWeAreDetailDtos;
using RealEstate_Dapper_Api.Repositories.ServiceRepositories;
using RealEstate_Dapper_Api.Repositories.WhoWeAreDetailRepositories;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        private readonly IServiceRepository _repository;

        public ServicesController(IServiceRepository repository)
        {
            _repository = repository;   
        }


        [HttpGet]
        public async Task<IActionResult> ServiceList()
        {
            var values = await _repository.GetAllServiceAsync();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetService(int id)
        {
            var value = await _repository.GetByIdServiceAsync(id);
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateService(CreateServiceDto createServiceDto)
        {
            _repository.CreateServiceAsync(createServiceDto);
            return Ok("Başarılı bir şekilde eklendi");
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> AddService(CreateServiceDto createServiceDto)
        {
            AddServiceDto newService = await _repository.AddServiceAsync(createServiceDto);
            return Ok(newService);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteService(int id)
        {
            _repository.DeleteServiceAsync(id);
            return Ok("Başarılı bir şekilde silindi");
        }   

        [HttpPut]
        public async Task<IActionResult> UpdateService(UpdateServiceDto updateServiceDto)
        {
            _repository.UpdateServiceAsync(updateServiceDto);
            return Ok("Başarılı bir şekilde güncellendi");
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> SwitchStatusServiceAsync(int id)
        {
            _repository.SwitchStatusServiceAsync(id);
            return Ok("Başarılı bir şekilde durum değişti");
        }
    }
}
