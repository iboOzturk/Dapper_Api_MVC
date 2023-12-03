using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.DTOs.CategoryDtos;
using RealEstate_Dapper_UI.DTOs.ProductDtos;
using System.Text;

namespace RealEstate_Dapper_UI.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        string url = "https://localhost:44383/api/Products/GetAllProductsWithCategory/";
        string CUDurl = "https://localhost:44383/api/Products/";
        string CategoriesUrl = "https://localhost:44383/api/Categories/";



        public ProductsController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client=_httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync(url);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData=await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultProductDto>>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> AddProduct()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage=await client.GetAsync(CategoriesUrl);          
                var jsonData=await responseMessage.Content.ReadAsStringAsync();
                var values=JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);
            List<SelectListItem> categoryValues = (from x in values.ToList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryID.ToString(),
                                                   }).ToList();
            ViewBag.v=categoryValues;
            
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddProduct(CreateProductDto createProductDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createProductDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync(CUDurl, stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Products");
            }
            return View();
        }

        public async Task<IActionResult> ChangeDealOfTheDay(int id) 
        {
            var client = _httpClientFactory.CreateClient();

            var jsonData = new { id };
            var content = new StringContent(JsonConvert.SerializeObject(jsonData), Encoding.UTF8, "application/json");


            var responseMessage = await client.PutAsync(CUDurl + id, content);  
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            else
            {
                var errorMessage = await responseMessage.Content.ReadAsStringAsync();
                return View("Error", errorMessage);
            }

        }
    }
}
