using RealEstate_Dapper_Api.DTOs.CategoryDtos;
using RealEstate_Dapper_Api.DTOs.WhoWeAreDetailDtos;

namespace RealEstate_Dapper_Api.Repositories.WhoWeAreDetailRepositories
{
    public interface IWhoWeAreDetailRepository  
    {
        Task<List<ResultWhoWeAreDetailDto>> GetAllWhoWeAreDetailAsync();        
        void CreateWhoWeAreDetailAsync(CreateWhoWeAreDetailDto createWhoWeAreDetailDto);
        void DeleteWhoWeAreDetailAsync(int id);
        void UpdateWhoWeAreDetailAsync(UpdateWhoWeAreDetailDto updateWhoWeAreDetailDto);

        Task<GetByIdWhoWeAreDetailDto> GetByIdWhoWeAreDetailAsync(int id);  

    }
}
