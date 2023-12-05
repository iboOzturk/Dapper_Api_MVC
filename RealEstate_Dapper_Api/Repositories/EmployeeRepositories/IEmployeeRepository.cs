using RealEstate_Dapper_Api.DTOs.EmployeeDtos;

namespace RealEstate_Dapper_Api.Repositories.EmployeeRepositories
{
    public interface IEmployeeRepository
    {
        Task<List<ResultEmployeeDto>> GetAllEmployeeAsync();
        Task<GetByIdEmployeeDto> GetByIdEmployeeAsync(int id);
        void CreateEmployeeAsync(CreateEmployeeDto createEmployeeDto);
        void DeleteEmployeeAsync(int id);   
        void UpdateEmployeeAsync(UpdateEmployeeDto updateEmployeeDto);
        void ChangeStatusAsync(int id);

    }
}
