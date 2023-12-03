using RealEstate_Dapper_Api.DTOs.ProductDtos;

namespace RealEstate_Dapper_Api.Repositories.ProductRepositories
{
    public interface IProductRepository
    {
        Task<List<ResultProductDto>> GetAllProductAsync();  
        Task<List<ResultProductWithCategoryDto>> GetAllProductWithCategoryAsync();
        void CreateProductAsync(CreateProductDto createProductDto);
        void DeleteProductAsync(int id);    
        void UpdateProductAsync(UpdateProductDto updateProductDto);
        void SwitchStatusDOTDAsync(int id); 

    }
}
