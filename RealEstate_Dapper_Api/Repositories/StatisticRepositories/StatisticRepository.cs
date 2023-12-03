using Dapper;
using RealEstate_Dapper_Api.DTOs.ProductDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.StatisticRepositories
{
    public class StatisticRepository : IStatisticRepository
    {
        private readonly Context _context;

        public StatisticRepository(Context context)
        {
            _context = context;
        }

        public int ActiveCategoryCount()
        {
            string query = "select count(*) from Category where CategoryStatus=1 ";
            //var parameter = new DynamicParameters();
            //parameter.Add("@categoryID", id);
            using (var connection = _context.CreateConnection())
            {
                var value = connection.QueryFirstOrDefault<int>(query);

                return value;
            }
        }

        public int ActiveEmployeeCount()
        {
            string query = "select count(*) from Employee where Status=1 ";

            using (var connection = _context.CreateConnection())
            {
                var value = connection.QueryFirstOrDefault<int>(query);

                return value;
            }
        }

        public int ApartmentCount()
        {
            string query = "Select count(*) from Product where ProductCategory=3";

            using (var connection = _context.CreateConnection())
            {
                var value = connection.QueryFirstOrDefault<int>(query);

                return value;
            }
        }

        public decimal AvgProductByRentPrice()
        {
            string query = "select AVG(Price) from Product where Type='Kiralık'";

            using (var connection = _context.CreateConnection())
            {
                var value = connection.QueryFirstOrDefault<decimal>(query);

                return value;
            }
        }

        public decimal AvgProductBySalePrice()
        {
            string query = "select AVG(Price) from Product where Type='Satılık'";

            using (var connection = _context.CreateConnection())
            {
                var value = connection.QueryFirstOrDefault<decimal>(query);

                return value;
            }
        }

        public int AvgRoomCount()
        {
            string query = "select AVG(RoomCount) from ProductDetails ";

            using (var connection = _context.CreateConnection())
            {
                var value = connection.QueryFirstOrDefault<int>(query);

                return value;
            }
        }

        public int CategoryCount()
        {
            string query = "select count(*) from Category";

            using (var connection = _context.CreateConnection())
            {
                var value = connection.QueryFirstOrDefault<int>(query);

                return value;
            }
        }

        public string CategoryNameByMaxProductCount()
        {
            string query = "select top(1) CategoryName from Product inner join Category on Product.ProductCategory=Category.CategoryID group by CategoryName order by count(*) desc";

            using (var connection = _context.CreateConnection())
            {
                var value = connection.QueryFirstOrDefault<string>(query);

                return value;
            }
        }

        public string CityNameByMaxProductCount()
        {
            string query = "select top(1) City from Product  group by City order by count(*) desc";

            using (var connection = _context.CreateConnection())
            {
                var value = connection.QueryFirstOrDefault<string>(query);

                return value;
            }
        }

        public int DifferentCityCount()
        {
            string query = "SELECT count( DISTINCT City) FROM Product";

            using (var connection = _context.CreateConnection())
            {
                var value = connection.QueryFirstOrDefault<int>(query);

                return value;
            }
        }

        public string EmployeeNameByMaxProductCount()
        {
            string query = "select top(1) e.Name from Product p inner join Employee e on p.EmployeeID=e.EmployeeID group by e.Name order by count(*) desc";

            using (var connection = _context.CreateConnection())
            {
                var value = connection.QueryFirstOrDefault<string>(query);

                return value;
            }
        }

        public async Task<List<ResultProductDto>> GetLast5Produc()
        {
            string query = "select Top(5) * from Product order by ProductID desc";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultProductDto>(query);
                return values.ToList();
            }

        }

        public decimal LastProductPrice()
        {
            string query = "select top(1) Price from Product order by ProductID desc";

            using (var connection = _context.CreateConnection())
            {
                var value = connection.QueryFirstOrDefault<decimal>(query);

                return value;
            }
        }

        public string NewestBuildYear()
        {
            string query = "select top(1) BuildYear from ProductDetails order by BuildYear desc";

            using (var connection = _context.CreateConnection())
            {
                var value = connection.QueryFirstOrDefault<string>(query);

                return value;
            }
        }

        public string OldestBuildYear()
        {
            string query = "select top(1) BuildYear from ProductDetails order by BuildYear ";

            using (var connection = _context.CreateConnection())
            {
                var value = connection.QueryFirstOrDefault<string>(query);

                return value;
            }
        }

        public int PassiveCategoryCount()
        {
            string query = "select Count(*) from Category where CategoryStatus=0";

            using (var connection = _context.CreateConnection())
            {
                var value = connection.QueryFirstOrDefault<int>(query);

                return value;
            }
        }

        public int ProductCount()
        {
            string query = "select count(*) from Product ";

            using (var connection = _context.CreateConnection())
            {
                var value = connection.QueryFirstOrDefault<int>(query);

                return value;
            }
        }
    }
}
