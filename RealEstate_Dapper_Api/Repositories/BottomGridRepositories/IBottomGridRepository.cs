using RealEstate_Dapper_Api.DTOs.BottomGridDtos;
using RealEstate_Dapper_Api.DTOs.CategoryDtos;

namespace RealEstate_Dapper_Api.Repositories.BottomGridRepositories
{
    public interface IBottomGridRepository
    {
        Task<List<ResultBottomGridDto>> GetAllBottomGridAsync();    
        void CreateBottomGridAsync(CreateBottomGridDto createBottomGridDto);
        void DeleteBottomGridAsync(int id);
        void UpdateBottomGridAsync(UpdateBottomGridDto updateBottomGridDto);
            
        Task<GetByIdBottomGridDto> GetByIdBottomGridAsync(int id);
    }
}
