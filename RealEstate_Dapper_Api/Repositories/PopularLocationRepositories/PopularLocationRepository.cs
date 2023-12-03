using Dapper;
using RealEstate_Dapper_Api.DTOs.PopularLocationDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.PopularLocationRepositories
{
    public class PopularLocationRepository : IPopularLocationRepository
    {
        private readonly Context _context;

        public PopularLocationRepository(Context context)
        {
            _context = context;
        }

        public async void CreatePopularLocationAsync(CreatePopularLocationDto createPopularLocationDto)
        {
            string query = "insert into PopularLocation (CityName,ImageUrl)" +
                " values (@CityName,@ImageUrl)";
            var parameters = new DynamicParameters();
            parameters.Add("@CityName", createPopularLocationDto.CityName);
            parameters.Add("@ImageUrl", createPopularLocationDto.ImageUrl);
           
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async void DeletePopularLocationAsync(int id)
        {
            string query = "Delete from PopularLocation where LocationID=@LocationID";
            var parameters = new DynamicParameters();
            parameters.Add("@LocationID", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<List<ResultPopularLocationDto>> GetAllPopularLocationAsync()
        {
            string query = "Select * from PopularLocation";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultPopularLocationDto>(query);
                return values.ToList();
            }   
        }

        public async Task<GetByIdPopularLocationDto> GetByIdPopularLocationAsync(int id)
        {
            string query = "Select * from PopularLocation where LocationID=@LocationID";
            var parametres = new DynamicParameters();
            parametres.Add("@LocationID", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<GetByIdPopularLocationDto>(query, parametres);
                return values;
            }
        }

        public async void UpdatePopularLocationAsync(UpdatePopularLocationDto updatePopularLocationDto)
        {
            string query = "Update PopularLocation " +
                 "set CityName=@CityName,ImageUrl=@ImageUrl " +
                 "where LocationID=@LocationID ";
            var parameters = new DynamicParameters();
            parameters.Add("@CityName", updatePopularLocationDto.CityName);
     
            parameters.Add("@ImageUrl", updatePopularLocationDto.ImageUrl);
          
            parameters.Add("@LocationID", updatePopularLocationDto.LocationID);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
