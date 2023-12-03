using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.DTOs.WhoWeAreDetailDtos;

namespace RealEstate_Dapper_UI.ViewComponents.HomePage
{
    public class _DefaultWhoWeAreComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public _DefaultWhoWeAreComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var client2 = _httpClientFactory.CreateClient();


            var responseMessage = await client.GetAsync("https://localhost:44383/api/WhoWeAreDetails");
            var responseServiceMessage = await client2.GetAsync("https://localhost:44383/api/Services");

            if (responseMessage.IsSuccessStatusCode && responseServiceMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var jsonServiceData = await responseServiceMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultWhoWeAreDetailDto>>(jsonData);
                var serviceValues = JsonConvert.DeserializeObject<List<ResultServiceDto>>(jsonServiceData);

                ViewBag.Title = values.FirstOrDefault().Title;
                ViewBag.Subtitle = values.FirstOrDefault().Subtitle;
                ViewBag.Desc1 = values.FirstOrDefault().Description1;
                ViewBag.Desc2 = values.FirstOrDefault().Description2;
                return View(serviceValues);

            }
            
            return View();

            
          
        }
    }
}
