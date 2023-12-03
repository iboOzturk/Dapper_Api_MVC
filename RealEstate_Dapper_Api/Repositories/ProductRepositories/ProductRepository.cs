using Dapper;
using RealEstate_Dapper_Api.DTOs.CategoryDtos;
using RealEstate_Dapper_Api.DTOs.ProductDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.ProductRepositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly Context _context;

        public ProductRepository(Context context)
        {
            _context = context;
        }

        public async void CreateProductAsync(CreateProductDto createProductDto)
        {
            string query = "insert into Product " +
                "(Title,Price,Type,CoverImage,City,District,Address,Description,ProductCategory,EmployeeID,DealOfTheDay,CreateDate)" +
                " values (@Title,@Price,@Type,@CoverImage,@City,@District,@Address,@Description," +
                "@ProductCategory,@EmployeeID,@DealOfTheDay,@CreateDate)";
            var parameters = new DynamicParameters();
            parameters.Add("@Title", createProductDto.Title);
            parameters.Add("@Price", createProductDto.Price);
            parameters.Add("@Type", createProductDto.Type);
            parameters.Add("@CoverImage", createProductDto.CoverImage);
            parameters.Add("@City", createProductDto.City);
            parameters.Add("@District", createProductDto.District);
            parameters.Add("@Address", createProductDto.Address);
            parameters.Add("@Description", createProductDto.Description);
            parameters.Add("@ProductCategory", createProductDto.ProductCategory);
            parameters.Add("@EmployeeID", createProductDto.EmployeeID);
            parameters.Add("@DealOfTheDay", createProductDto.DealOfTheDay);
            parameters.Add("@CreateDate", DateTime.Now);
          
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
        public async void UpdateProductAsync(UpdateProductDto updateProductDto)
        {
            string query = "Update Product " +
                "set Title=@Title,Price=@Price,Type=@Type," +
                "CoverImage=@CoverImage,City=@City,District=@District," +
                "Address=@Address,Description=@Description," +
                "ProductCategory=@ProductCategory,EmployeeID=@EmployeeID,DealOfTheDay=@DealOfTheDay " +
                "where ProductID=@ProductID ";
            var parameters = new DynamicParameters();
            parameters.Add("@Title", updateProductDto.Title);
            parameters.Add("@Price", updateProductDto.Price);
            parameters.Add("@Type", updateProductDto.Type);
            parameters.Add("@CoverImage", updateProductDto.CoverImage);
            parameters.Add("@City", updateProductDto.City);
            parameters.Add("@District", updateProductDto.District);
            parameters.Add("@Address", updateProductDto.Address);
            parameters.Add("@Description", updateProductDto.Description);
            parameters.Add("@ProductCategory", updateProductDto.ProductCategory);
            parameters.Add("@EmployeeID", updateProductDto.EmployeeID);
            parameters.Add("@DealOfTheDay", updateProductDto.DealOfTheDay);
            parameters.Add("@ProductID", updateProductDto.ProductID);
           
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async void DeleteProductAsync(int id)
        {
            string query = "Delete from Product where ProductID=@ProductID";
            var parameters = new DynamicParameters();
            parameters.Add("@ProductID", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<List<ResultProductDto>> GetAllProductAsync()
        {
            string query = "Select * from Product";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultProductDto>(query);
                return values.ToList();
            }
        }

        public async Task<List<ResultProductWithCategoryDto>> GetAllProductWithCategoryAsync()
        {
            string query = "select ProductID,Title,Price,Type,CoverImage,City,District," +
                "Address,Description,CategoryName,DealOfTheDay,CreateDate from Product" +
                " inner join Category on Product.ProductCategory=Category.CategoryID";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultProductWithCategoryDto>(query);
                return values.ToList();
            }
        }

        public async void SwitchStatusDOTDAsync(int id)
        {
            var query = "UPDATE Product SET DealOfTheDay = CASE WHEN DealOfTheDay = 1 THEN 0 ELSE 1 END WHERE ProductID = @ProductID";
            var parametres = new DynamicParameters();
            parametres.Add("@ProductID", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parametres);
            }
        }
    }
}
