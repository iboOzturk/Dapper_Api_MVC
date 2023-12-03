using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Repositories.StatisticRepositories;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticsController : ControllerBase
    {
        private readonly IStatisticRepository _statisticRepository;

        public StatisticsController(IStatisticRepository statisticRepository)
        {
            _statisticRepository = statisticRepository;
        }

        [HttpGet("[action]")]
        public IActionResult ActiveCategoryCount()
        {
           var response= _statisticRepository.ActiveCategoryCount();
            return Ok(response);
        }
        [HttpGet("[action]")]
        public IActionResult ActiveEmployeeCount()
        {
            var response = _statisticRepository.ActiveEmployeeCount();
            return Ok(response);
        }
        [HttpGet("[action]")]
        public IActionResult ApartmentCount()
        {
            var response = _statisticRepository.ApartmentCount();
            return Ok(response);
        }
        [HttpGet("[action]")]
        public IActionResult AvgProductByRentPrice()
        {
            var response = _statisticRepository.AvgProductByRentPrice();
            return Ok(response);
        }
        [HttpGet("[action]")]
        public IActionResult AvgProductBySalePrice()
        {
            var response = _statisticRepository.AvgProductBySalePrice();
            return Ok(response);
        }
        [HttpGet("[action]")]
        public IActionResult AvgRoomCount()
        {
            var response = _statisticRepository.AvgRoomCount();
            return Ok(response);
        }
        [HttpGet("[action]")]
        public IActionResult CategoryCount()
        {
            var response = _statisticRepository.CategoryCount();
            return Ok(response);
        }
        [HttpGet("[action]")]
        public IActionResult CategoryNameByMaxProductCount()
        {
            var response = _statisticRepository.CategoryNameByMaxProductCount();
            return Ok(response);
        }
        [HttpGet("[action]")]
        public IActionResult CityNameByMaxProductCount()
        {
            var response = _statisticRepository.CityNameByMaxProductCount();
            return Ok(response);
        }
        [HttpGet("[action]")]
        public IActionResult DifferentCityCount()
        {
            var response = _statisticRepository.DifferentCityCount();
            return Ok(response);
        }
        [HttpGet("[action]")]
        public IActionResult EmployeeNameByMaxProductCount()
        {
            var response = _statisticRepository.EmployeeNameByMaxProductCount();
            return Ok(response);
        }
        [HttpGet("[action]")]
        public IActionResult LastProductPrice()
        {
            var response = _statisticRepository.LastProductPrice();
            return Ok(response);
        }
        [HttpGet("[action]")]
        public IActionResult NewestBuildYear()
        {
            var response = _statisticRepository.NewestBuildYear();
            return Ok(response);
        }
        [HttpGet("[action]")]
        public IActionResult OldestBuildYear()
        {
            var response = _statisticRepository.OldestBuildYear();
            return Ok(response);
        }
        [HttpGet("[action]")]
        public IActionResult PassiveCategoryCount()
        {
            var response = _statisticRepository.PassiveCategoryCount();
            return Ok(response);
        }
        [HttpGet("[action]")]
        public IActionResult ProductCount()
        {
            var response = _statisticRepository.ProductCount();
            return Ok(response);
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetLast5Produc()   
        {
            var response = await _statisticRepository.GetLast5Produc();
            return Ok(response);
        }
    }
}
