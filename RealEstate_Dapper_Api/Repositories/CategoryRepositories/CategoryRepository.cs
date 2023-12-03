using Dapper;
using RealEstate_Dapper_Api.DTOs.CategoryDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.CategoryRepositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly Context _context;

        public CategoryRepository(Context context)
        {
            _context = context;
        }

        public async void CreateCategoryAsync(CreateCategoryDto categoryDto)
        {
            string query = "insert into Category (CategoryName,CategoryStatus) values (@categoryName,@categoryStatus)";
            var parameters = new DynamicParameters();
            parameters.Add("@categoryName", categoryDto.CategoryName);
            parameters.Add("@categoryStatus", true);
            using (var connection=_context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async void DeleteCategoryAsync(int id)
        {
            string query = "Delete from Category where CategoryID=@categoryID";
            var parameters = new DynamicParameters();
            parameters.Add("@categoryID", id);
            using (var connection=_context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<List<ResultCategoryDto>> GetAllCategoryAsync()
        {
            string query = "Select * from Category";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultCategoryDto>(query);
                return values.ToList();
            }
        }

        public async Task<GetByIdCategoryDto> GetByIdCategoryAsync(int id)
        {
            string query = "Select * from category where CategoryID=@categoryID";
            var parameter = new DynamicParameters();
            parameter.Add("@categoryID", id);
            using(var connection=_context.CreateConnection())
            {
                var value=await connection.QueryFirstOrDefaultAsync<GetByIdCategoryDto>(query,parameter);

                return value; 
            }

        }

        public async void UpdateCategoryAsync(UpdateCategoryDto categoryDto)
        {
            string query = "Update Category " +
                "set CategoryName=@categoryName,CategoryStatus=@categoryStatus " +
                "where CategoryID=@categoryID ";
            var parameters= new DynamicParameters();
            parameters.Add("@categoryName", categoryDto.CategoryName);
            parameters.Add("@categoryStatus", categoryDto.CategoryStatus);
            parameters.Add("@categoryID", categoryDto.CategoryID);  
            using (var connection=_context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
