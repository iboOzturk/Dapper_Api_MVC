using RealEstate_Dapper_Api.DTOs.ContactDtos;

namespace RealEstate_Dapper_Api.Repositories.ContactRepositories
{
    public interface IContactRepository
    {
        Task<List<ResultContactDto>> GetAllContactAsync();
        Task<List<ResultContactDto>> GetLast4ContactAsync();
        Task<GetByIdContactDto> GetByIdContactAsync(int id);
        void CreateContactAsync(CreateContactDto createContactDto);
        void DeleteContactAsync(int id);    
    }
}
