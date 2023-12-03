using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.DTOs.ProductDtos;
using RealEstate_Dapper_Api.Repositories.ProductRepositories;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var value=await _productRepository.GetAllProductAsync();
            return Ok(value);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllProductsWithCategory()   
        {
            var value = await _productRepository.GetAllProductWithCategoryAsync();
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductDto createProductDto)
        {
            _productRepository.CreateProductAsync(createProductDto);
            return Ok("Başarılı bir şekilde eklendi");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            _productRepository.DeleteProductAsync(id);
            return Ok("Başarılı bir şekilde silindi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct(UpdateProductDto updateProductDto)
        {
            _productRepository.UpdateProductAsync(updateProductDto);
            return Ok("Başarılı bir şekilde güncellendi");
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> SwitchStatusServiceAsync(int id)
        {
            _productRepository.SwitchStatusDOTDAsync(id);
            return Ok("Başarılı bir şekilde durum değişti");
        }
    }
}
