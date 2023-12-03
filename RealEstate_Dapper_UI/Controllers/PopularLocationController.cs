using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.DTOs.PopularLocationDtos;
using System.Text;

namespace RealEstate_Dapper_UI.Controllers
{
    public class PopularLocationController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        string url = "https://localhost:44383/api/PopularLocations/";

        public PopularLocationController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory; 
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync(url);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultPopularLocationDto>>(jsonData);
                return View(values);

            }
            return View();
        }
        [HttpGet]
        public IActionResult AddPopularLocations()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddPopularLocations(LocationImageFileDto locationImage)
        {
            CreatePopularLocationDto createServiceDto =new CreatePopularLocationDto();
            var client = _httpClientFactory.CreateClient();         

            if (locationImage.ImageUrl != null && locationImage.ImageUrl.Length > 0)
            {
                var extension = Path.GetExtension(locationImage.ImageUrl.FileName);
                var newimagename = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/cityimages/", newimagename);
                var stream = new FileStream(location, FileMode.Create);
                locationImage.ImageUrl.CopyTo(stream);
                createServiceDto.ImageUrl = "/cityimages/" + newimagename;
            }
            createServiceDto.CityName= locationImage.CityName;
            var jsonData = JsonConvert.SerializeObject(createServiceDto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync(url, content);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View();

          
        }
        public async Task<IActionResult> DeletePopularLocations(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync(url + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> UpdatePopularLocations(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync(url + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdatePopularLocationDto>(jsonData);
                ViewBag.ImageUrl = values.ImageUrl;
                return View(values);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdatePopularLocations(UpdateLocationImageDto locationImage)
        {
            UpdatePopularLocationDto updatePopularLocationDto= new UpdatePopularLocationDto();

            var client = _httpClientFactory.CreateClient();
            if (locationImage.ImageUrl != null && locationImage.ImageUrl.Length > 0)
            {
                var extension = Path.GetExtension(locationImage.ImageUrl.FileName);
                var newimagename = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/cityimages/", newimagename);
                var stream = new FileStream(location, FileMode.Create);
                locationImage.ImageUrl.CopyTo(stream);
                //w.WriterImage = newimagename;
                updatePopularLocationDto.ImageUrl = "/cityimages/" + newimagename;
            }
            updatePopularLocationDto.LocationID= locationImage.LocationID;
            updatePopularLocationDto.CityName = locationImage.CityName;
            var jsonData = JsonConvert.SerializeObject(updatePopularLocationDto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync(url, content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();

        }
    }
}
