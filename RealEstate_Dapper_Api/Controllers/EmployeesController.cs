using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.DTOs.EmployeeDtos;
using RealEstate_Dapper_Api.Repositories.EmployeeRepositories;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase   
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeesController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        [HttpGet]
        public async Task<IActionResult> EmployeeList()
        {
            var values = await _employeeRepository.GetAllEmployeeAsync();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployee(int id)
        {
            var values = await _employeeRepository.GetByIdEmployeeAsync(id);
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateEmployee(CreateEmployeeDto createEmployeeDto)    
        {
             _employeeRepository.CreateEmployeeAsync(createEmployeeDto);
            return Ok("Başarılı bir şekilde eklendi");
        }
        [HttpDelete("{id}")]
        public  IActionResult DeleteEmployee(int id)
        {
            _employeeRepository.DeleteEmployeeAsync(id);
            return Ok("Başarılı bir şekilde silindi");
        }

        [HttpPut]
        public  IActionResult UpdateEmployee(UpdateEmployeeDto updateEmployeeDto)
        {
            _employeeRepository.UpdateEmployeeAsync(updateEmployeeDto);
            return Ok("Başarılı bir şekilde güncellendi");
        }
        [HttpPut("[action]")]
        public async Task<IActionResult> ChangeEmployeeStatus(int id)
        {
              _employeeRepository.ChangeStatusAsync(id);
            return Ok("Durum Değiştirildi");

        }
    }
}
