using RealEstate_Dapper_Api.DTOs.CategoryDtos;
using RealEstate_Dapper_Api.DTOs.PopularLocationDtos;

namespace RealEstate_Dapper_Api.Repositories.PopularLocationRepositories
{
    public interface IPopularLocationRepository
    {
        Task<List<ResultPopularLocationDto>> GetAllPopularLocationAsync();
        Task<GetByIdPopularLocationDto> GetByIdPopularLocationAsync(int id);    

        void DeletePopularLocationAsync(int id);

        void CreatePopularLocationAsync(CreatePopularLocationDto createPopularLocationDto);
        void UpdatePopularLocationAsync(UpdatePopularLocationDto updatePopularLocationDto);
      

    }
}
