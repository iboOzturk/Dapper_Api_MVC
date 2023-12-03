using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.DTOs.CategoryDtos;
using RealEstate_Dapper_Api.DTOs.WhoWeAreDetailDtos;
using RealEstate_Dapper_Api.Repositories.WhoWeAreDetailRepositories;


namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WhoWeAreDetailsController : ControllerBase
    {
        private readonly IWhoWeAreDetailRepository _repository;

        public WhoWeAreDetailsController(IWhoWeAreDetailRepository repository)
        {
            _repository = repository;
        }


        [HttpGet]   
        public async Task<IActionResult> WhoWeAreDetailList()
        {
            var values = await _repository.GetAllWhoWeAreDetailAsync();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetWhoWeAreDetail(int id)
        {
            var value = await _repository.GetByIdWhoWeAreDetailAsync(id);
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateWhoWeAreDetail(CreateWhoWeAreDetailDto createWhoWeAreDetailDto)
        {
            _repository.CreateWhoWeAreDetailAsync(createWhoWeAreDetailDto);
            return Ok("Başarılı bir şekilde eklendi");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWhoWeAreDetail(int id)
        {
            _repository.DeleteWhoWeAreDetailAsync(id);
            return Ok("Başarılı bir şekilde silindi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateWhoWeAreDetail(UpdateWhoWeAreDetailDto updateWhoWeAreDetailDto)
        {
            _repository.UpdateWhoWeAreDetailAsync(updateWhoWeAreDetailDto);
            return Ok("Başarılı bir şekilde güncellendi");  
        }
    }
}
