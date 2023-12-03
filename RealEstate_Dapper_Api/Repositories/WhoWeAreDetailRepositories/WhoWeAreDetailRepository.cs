using Dapper;
using RealEstate_Dapper_Api.DTOs.WhoWeAreDetailDtos;
using RealEstate_Dapper_Api.Models.DapperContext;
using RealEstate_Dapper_Api.Repositories.WhoWeAreDetailRepositories;

namespace RealEstate_Dapper_Api.Repositories.WhoWeAreRepositories
{
    public class WhoWeAreDetailRepository :IWhoWeAreDetailRepository
    {
        private readonly Context _context;

        public WhoWeAreDetailRepository(Context context)
        {
            _context = context;
        }

        public async void CreateWhoWeAreDetailAsync(CreateWhoWeAreDetailDto createWhoWeAreDetailDto)
        {
            string query = "insert into WhoWeAreDetail (Title,Subtitle,Description1,Description2 )" +
                " values (@Title,@Subtitle,@Description1,@Description2)";
            var parameters = new DynamicParameters();
            parameters.Add("@Title", createWhoWeAreDetailDto.Title);
            parameters.Add("@Subtitle", createWhoWeAreDetailDto.Subtitle);
            parameters.Add("@Description1", createWhoWeAreDetailDto.Description1);
            parameters.Add("@Description2", createWhoWeAreDetailDto.Description2);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async void DeleteWhoWeAreDetailAsync(int id)
        {
            string query = "Delete from WhoWeAreDetail where WhoWeAreDetailID=@WhoWeAreDetailID";
            var parameters = new DynamicParameters();
            parameters.Add("@WhoWeAreDetailID", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<List<ResultWhoWeAreDetailDto>> GetAllWhoWeAreDetailAsync()
        {
            string query = "Select * from WhoWeAreDetail";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultWhoWeAreDetailDto>(query);
                return values.ToList();
            }
        }

        public async Task<GetByIdWhoWeAreDetailDto> GetByIdWhoWeAreDetailAsync(int id)
        {
            string query = "Select * from WhoWeAreDetail where WhoWeAreDetailID=@WhoWeAreDetailID";
            var parameter = new DynamicParameters();
            parameter.Add("@WhoWeAreDetailID", id);
            using (var connection = _context.CreateConnection())
            {
                var value = await connection.QueryFirstOrDefaultAsync<GetByIdWhoWeAreDetailDto>(query, parameter);

                return value;
            }
        }

        public async void UpdateWhoWeAreDetailAsync(UpdateWhoWeAreDetailDto updateWhoWeAreDetailDto)
        {
            string query = "Update WhoWeAreDetail " +
                "set Title=@Title,Subtitle=@Subtitle,Description1=@Description1,Description2=@Description2 " +
                "where WhoWeAreDetailID=@WhoWeAreDetailID ";
            var parameters = new DynamicParameters();
            parameters.Add("@Title", updateWhoWeAreDetailDto.Title);
            parameters.Add("@Subtitle", updateWhoWeAreDetailDto.Subtitle);
            parameters.Add("@Description1", updateWhoWeAreDetailDto.Description1);
            parameters.Add("@Description2", updateWhoWeAreDetailDto.Description2);
            parameters.Add("@WhoWeAreDetailID", updateWhoWeAreDetailDto.WhoWeAreDetailID);
           
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
