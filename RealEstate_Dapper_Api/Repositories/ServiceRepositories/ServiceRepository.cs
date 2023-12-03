using Dapper;
using RealEstate_Dapper_Api.DTOs.CategoryDtos;
using RealEstate_Dapper_Api.DTOs.ServiceDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.ServiceRepositories
{
    public class ServiceRepository : IServiceRepository
    {
        private readonly Context _context;

        public ServiceRepository(Context context)
        {
            _context = context;
        }

      

        public async Task<AddServiceDto> AddServiceAsync(CreateServiceDto createServiceDto)
        {
            string query = "INSERT INTO Service (ServiceName, ServiceStatus) VALUES (@ServiceName, @ServiceStatus); SELECT SCOPE_IDENTITY();";
            
            var parameters = new DynamicParameters();
            parameters.Add("@ServiceName", createServiceDto.ServiceName);
            parameters.Add("@ServiceStatus", true);

            using (var connection = _context.CreateConnection())
            {                
                int newServiceId = await connection.QuerySingleAsync<int>(query, parameters);
                
                AddServiceDto newService = await connection.QuerySingleAsync<AddServiceDto>("SELECT * FROM Service WHERE ServiceId = @ServiceId", new { ServiceId = newServiceId });

                return newService;
            }
        }

        public async void CreateServiceAsync(CreateServiceDto createServiceDto)
        {
            string query = "insert into Service (ServiceName,ServiceStatus) values (@ServiceName,@ServiceStatus)";
            var parameters = new DynamicParameters();
            parameters.Add("@ServiceName", createServiceDto.ServiceName);
            parameters.Add("@ServiceStatus", true);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async void DeleteServiceAsync(int id)
        {
            string query = "Delete from Service where ServiceID=@ServiceID";
            var parameters = new DynamicParameters();
            parameters.Add("@ServiceID", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<List<ResultServiceDto>> GetAllServiceAsync()
        {
            string query = "Select * from Service";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultServiceDto>(query);
                return values.ToList();
            }
        }

        public async Task<GetByIdServiceDto> GetByIdServiceAsync(int id)
        {
            string query = "Select * from Service where ServiceID=@ServiceID";
            var parameter = new DynamicParameters();
            parameter.Add("@ServiceID", id);
            using (var connection = _context.CreateConnection())
            {
                var value = await connection.QueryFirstOrDefaultAsync<GetByIdServiceDto>(query, parameter);

                return value;
            }
        }

        public async void SwitchStatusServiceAsync(int id)
        {
            var query = "UPDATE Service SET ServiceStatus = CASE WHEN ServiceStatus = 1 THEN 0 ELSE 1 END WHERE ServiceID = @ServiceID";
            var parametres= new DynamicParameters();           
            parametres.Add("@ServiceID" , id);
            using (var connection =_context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parametres);
            }
        }

        public async void UpdateServiceAsync(UpdateServiceDto updateServiceDto)
        {
            string query = "Update Service " +
                  "set ServiceName=@ServiceName,ServiceStatus=@ServiceStatus " +
                  "where ServiceID=@ServiceID ";
            var parameters = new DynamicParameters();
            parameters.Add("@ServiceName", updateServiceDto.ServiceName);
            parameters.Add("@ServiceStatus", updateServiceDto.ServiceStatus);
            parameters.Add("@ServiceID", updateServiceDto.ServiceID);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
