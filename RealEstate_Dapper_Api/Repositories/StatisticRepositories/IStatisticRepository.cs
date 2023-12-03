using RealEstate_Dapper_Api.DTOs.ProductDtos;

namespace RealEstate_Dapper_Api.Repositories.StatisticRepositories
{
    public interface IStatisticRepository
    {
        int CategoryCount();
        int ActiveCategoryCount();
        int PassiveCategoryCount();
        int ProductCount();
        int ApartmentCount();
        string EmployeeNameByMaxProductCount();     
        string CategoryNameByMaxProductCount(); 
        decimal AvgProductByRentPrice();
        decimal AvgProductBySalePrice();
        string CityNameByMaxProductCount();
        int DifferentCityCount();
        decimal LastProductPrice();
        string NewestBuildYear();
        string OldestBuildYear();
        int AvgRoomCount();
        int ActiveEmployeeCount();
        Task<List<ResultProductDto>> GetLast5Produc();
    }
}
