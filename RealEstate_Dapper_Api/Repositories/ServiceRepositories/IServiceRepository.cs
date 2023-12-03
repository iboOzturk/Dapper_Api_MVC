using RealEstate_Dapper_Api.DTOs.CategoryDtos;
using RealEstate_Dapper_Api.DTOs.ServiceDtos;

namespace RealEstate_Dapper_Api.Repositories.ServiceRepositories
{
    public interface IServiceRepository
    {
        Task<List<ResultServiceDto>> GetAllServiceAsync();
        void CreateServiceAsync(CreateServiceDto createServiceDto);
     
        Task<AddServiceDto> AddServiceAsync(CreateServiceDto createServiceDto);
        void DeleteServiceAsync(int id);
        void UpdateServiceAsync(UpdateServiceDto updateServiceDto);
        void SwitchStatusServiceAsync(int id);   

        Task<GetByIdServiceDto> GetByIdServiceAsync(int id);
    }
}
