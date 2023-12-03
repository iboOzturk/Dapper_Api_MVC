using Dapper;
using RealEstate_Dapper_Api.DTOs.BottomGridDtos;
using RealEstate_Dapper_Api.DTOs.CategoryDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.BottomGridRepositories
{
    public class BottomGridRepository : IBottomGridRepository
    {
        private readonly Context _context;

        public BottomGridRepository(Context context)
        {
            _context = context;
        }
        public async void CreateBottomGridAsync(CreateBottomGridDto createBottomGridDto)
        {
            string query = "insert into BottomGrid (Icon,Title,Description) values (@Icon,@Title,@Description)";
            var parameters = new DynamicParameters();
            parameters.Add("@Icon", createBottomGridDto.Icon);
            parameters.Add("@Title", createBottomGridDto.Title);
            parameters.Add("@Description", createBottomGridDto.Description);
           
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async void DeleteBottomGridAsync(int id)
        {
            string query = "Delete from BottomGrid where BottomGridID=@BottomGridID";
            var parameters = new DynamicParameters();
            parameters.Add("@BottomGridID", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<List<ResultBottomGridDto>> GetAllBottomGridAsync()
        {
            string query = "Select * from BottomGrid";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultBottomGridDto>(query);
                return values.ToList();
            }
        }

        public async Task<GetByIdBottomGridDto> GetByIdBottomGridAsync(int id)
        {
            string query = "Select * from BottomGrid where BottomGridID=@BottomGridID";
            var parameter = new DynamicParameters();
            parameter.Add("@BottomGridID", id);
            using (var connection = _context.CreateConnection())
            {
                var value = await connection.QueryFirstOrDefaultAsync<GetByIdBottomGridDto>(query, parameter);

                return value;
            }
        }

        public async void UpdateBottomGridAsync(UpdateBottomGridDto updateBottomGridDto)
        {
            string query = "Update BottomGrid " +
                "set Icon=@Icon,Title=@Title,Description=@Description " +
                "where BottomGridID=@BottomGridID ";
            var parameters = new DynamicParameters();
            parameters.Add("@Icon", updateBottomGridDto.Icon);
            parameters.Add("@Title", updateBottomGridDto.Title);
            parameters.Add("@Description", updateBottomGridDto.Description);
            parameters.Add("@BottomGridID", updateBottomGridDto.BottomGridID);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
