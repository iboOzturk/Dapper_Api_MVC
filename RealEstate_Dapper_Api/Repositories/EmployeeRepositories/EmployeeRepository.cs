using Dapper;
using RealEstate_Dapper_Api.DTOs.EmployeeDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.EmployeeRepositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly Context _context;

        public EmployeeRepository(Context context)
        {
            _context = context;
        }
        public async void CreateEmployeeAsync(CreateEmployeeDto createEmployeeDto)
        {
            string query = "insert into Employee (Name,Title,Mail,PhoneNumber,ImageUrl,Status)" +
                " values (@Name,@Title,@Mail,@PhoneNumber,@ImageUrl,@Status)";
            var parameters = new DynamicParameters();
            parameters.Add("@Name", createEmployeeDto.Name);
            parameters.Add("@Title", createEmployeeDto.Title);
            parameters.Add("@Mail", createEmployeeDto.Mail);
            parameters.Add("@PhoneNumber", createEmployeeDto.PhoneNumber);
            parameters.Add("@ImageUrl", createEmployeeDto.ImageUrl);
            parameters.Add("@Status", true);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async void DeleteEmployeeAsync(int id)
        {
            string query = "Delete from Employee where EmployeeID=@EmployeeID";
            var parameters = new DynamicParameters();
            parameters.Add("@EmployeeID", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<List<ResultEmployeeDto>> GetAllEmployeeAsync()
        {
            string query = "Select * from Employee";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultEmployeeDto>(query);
                return values.ToList();
            }
        }

        public async Task<GetByIdEmployeeDto> GetByIdEmployeeAsync(int id)
        {
            string query = "Select * from Employee where EmployeeID=@EmployeeID";
            var parametres=new DynamicParameters();
            parametres.Add("@EmployeeID", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<GetByIdEmployeeDto>(query,parametres);
                return values;
            }
        }

        public async void UpdateEmployeeAsync(UpdateEmployeeDto updateEmployeeDto)
        {
            string query = "Update Employee " +
                 "set Name=@Name,Title=@Title,Mail=@Mail,PhoneNumber=@PhoneNumber,ImageUrl=@ImageUrl " +
                 "where EmployeeID=@EmployeeID ";
            var parameters = new DynamicParameters();
            parameters.Add("@Name", updateEmployeeDto.Name);
            parameters.Add("@Title", updateEmployeeDto.Title);
            parameters.Add("@Mail", updateEmployeeDto.Mail);
            parameters.Add("@PhoneNumber", updateEmployeeDto.PhoneNumber);
            parameters.Add("@ImageUrl", updateEmployeeDto.ImageUrl);
            parameters.Add("@Status", true);
            parameters.Add("@EmployeeID", updateEmployeeDto.EmployeeID);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
