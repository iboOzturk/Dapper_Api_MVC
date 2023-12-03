using RealEstate_Dapper_Api.DTOs.CategoryDtos;

namespace RealEstate_Dapper_Api.Repositories.CategoryRepositories
{
    public interface ICategoryRepository
    {
        Task<List<ResultCategoryDto>> GetAllCategoryAsync();
        void CreateCategoryAsync(CreateCategoryDto categoryDto);
        void DeleteCategoryAsync(int id);
        void UpdateCategoryAsync(UpdateCategoryDto categoryDto);

        Task<GetByIdCategoryDto> GetByIdCategoryAsync(int id);


    }
}
