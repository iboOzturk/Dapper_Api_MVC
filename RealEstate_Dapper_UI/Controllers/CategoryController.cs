using Dapper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.DTOs.CategoryDtos;
using System.Data;
using System.Text;

namespace RealEstate_Dapper_UI.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private IDbConnection _context;
        string url = "https://localhost:44383/api/Categories/";

        public CategoryController(IHttpClientFactory httpClientFactory, IDbConnection context)
        {
            _httpClientFactory = httpClientFactory;
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync(url);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);
                return View(values);

            }
            return View();         
        }

        [HttpGet]
        public IActionResult AddCategory()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddCategory(AddCategoryDto addCategoryDto)
        {
            var client= _httpClientFactory.CreateClient();
            var jsonData=JsonConvert.SerializeObject(addCategoryDto);
            StringContent stringContent = new StringContent(jsonData,Encoding.UTF8,"application/json");
            var responseMessage = await client.PostAsync(url, stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index","Category");
            }
            return View();
        }
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var client= _httpClientFactory.CreateClient();           
            var responseMessage = await client.DeleteAsync(url+id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Category");
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> UpdateCategory(int id)
        {
            var client= _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync(url+id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData=await responseMessage.Content.ReadAsStringAsync();
                var values=JsonConvert.DeserializeObject<UpdateCategoryDto>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryDto updateCategoryDto)
        {
            var client= _httpClientFactory.CreateClient();
            var jsonData=JsonConvert.SerializeObject(updateCategoryDto);
            StringContent content = new StringContent(jsonData,Encoding.UTF8,"application/json");
            var responseMessage = await client.PutAsync(url, content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Category");
            }
            return View();

        }
        public async Task<IActionResult> SwitchStatus(int id)
        {
            var client=_httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync(url + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateCategoryDto>(jsonData);
                values.CategoryStatus = !values.CategoryStatus;

                var jsonUpdateData = JsonConvert.SerializeObject(values);
                StringContent content = new StringContent(jsonUpdateData, Encoding.UTF8, "application/json");
                var responseUpdateMessage = await client.PutAsync(url, content);

                var den = JsonConvert.DeserializeObject<UpdateCategoryDto>(jsonUpdateData);

                if (responseUpdateMessage.IsSuccessStatusCode)
                    return RedirectToAction("Index");

            }
            return View();

        }
                
        //Stored Procedure Kullanıldı
        public IActionResult ChangeStatus(int id)
        {
            DynamicParameters parameters = new();
            parameters.Add("@categoryId", id);
            _context.Execute("ToggleProductStatus", parameters, commandType: CommandType.StoredProcedure);
            return RedirectToAction("Index");
        }
    }
}
