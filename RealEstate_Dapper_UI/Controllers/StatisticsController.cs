using Microsoft.AspNetCore.Mvc;

namespace RealEstate_Dapper_UI.Controllers
{
    public class StatisticsController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        string url = "https://localhost:44383/api/Statistics/";

        public StatisticsController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            #region ActiveCategoryCount
            var client =_httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync(url+ "ActiveCategoryCount");
            var jsonData=await responseMessage.Content.ReadAsStringAsync();
            ViewBag.ActiveCategoryCount = jsonData;
            #endregion

            #region ActiveEmployeeCount
            var client2 = _httpClientFactory.CreateClient();
            var responseMessage2 = await client2.GetAsync(url + "ActiveEmployeeCount");
            var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
            ViewBag.ActiveEmployeeCount = jsonData2;
            #endregion

            #region ApartmentCount
            var client3 = _httpClientFactory.CreateClient();
            var responseMessage3 = await client3.GetAsync(url + "ApartmentCount");
            var jsonData3 = await responseMessage3.Content.ReadAsStringAsync();
            ViewBag.ApartmentCount = jsonData3;
            #endregion

            #region AvgProductByRentPrice
            var client4 = _httpClientFactory.CreateClient();
            var responseMessage4 = await client4.GetAsync(url + "AvgProductByRentPrice");
            var jsonData4 = await responseMessage4.Content.ReadAsStringAsync();
            ViewBag.AvgProductByRentPrice = jsonData4;
            #endregion

            #region AvgProductBySalePrice
            var client5 = _httpClientFactory.CreateClient();
            var responseMessage5 = await client5.GetAsync(url + "AvgProductBySalePrice");
            var jsonData5 = await responseMessage5.Content.ReadAsStringAsync();
            ViewBag.AvgProductBySalePrice = jsonData5;
            #endregion

            #region AvgRoomCount
            var client6 = _httpClientFactory.CreateClient();
            var responseMessage6 = await client6.GetAsync(url + "AvgRoomCount");
            var jsonData6 = await responseMessage6.Content.ReadAsStringAsync();
            ViewBag.AvgRoomCount = jsonData6;
            #endregion

            #region CategoryCount
            var client7 = _httpClientFactory.CreateClient();
            var responseMessage7 = await client7.GetAsync(url + "CategoryCount");
            var jsonData7 = await responseMessage7.Content.ReadAsStringAsync();
            ViewBag.CategoryCount = jsonData7;
            #endregion

            #region CategoryNameByMaxProductCount
            var client8 = _httpClientFactory.CreateClient();
            var responseMessage8 = await client8.GetAsync(url + "CategoryNameByMaxProductCount");
            var jsonData8 = await responseMessage8.Content.ReadAsStringAsync();
            ViewBag.CategoryNameByMaxProductCount = jsonData8;
            #endregion

            #region CityNameByMaxProductCount
            var client9 = _httpClientFactory.CreateClient();
            var responseMessage9 = await client9.GetAsync(url + "CityNameByMaxProductCount");
            var jsonData9 = await responseMessage9.Content.ReadAsStringAsync();
            ViewBag.CityNameByMaxProductCount = jsonData9;
            #endregion

            #region DifferentCityCount
            var client10 = _httpClientFactory.CreateClient();
            var responseMessage10 = await client10.GetAsync(url + "DifferentCityCount");
            var jsonData10 = await responseMessage10.Content.ReadAsStringAsync();
            ViewBag.DifferentCityCount = jsonData10;
            #endregion

            #region EmployeeNameByMaxProductCount
            var client11 = _httpClientFactory.CreateClient();
            var responseMessage11 = await client11.GetAsync(url + "EmployeeNameByMaxProductCount");
            var jsonData11 = await responseMessage11.Content.ReadAsStringAsync();
            ViewBag.EmployeeNameByMaxProductCount = jsonData11;
            #endregion

            #region LastProductPrice
            var client12 = _httpClientFactory.CreateClient();
            var responseMessage12 = await client12.GetAsync(url + "LastProductPrice");
            var jsonData12 = await responseMessage12.Content.ReadAsStringAsync();
            ViewBag.LastProductPrice = jsonData12;
            #endregion

            #region NewestBuildYear
            var client13 = _httpClientFactory.CreateClient();
            var responseMessage13 = await client13.GetAsync(url + "NewestBuildYear");
            var jsonData13 = await responseMessage13.Content.ReadAsStringAsync();
            ViewBag.NewestBuildYear = jsonData13;
            #endregion

            #region OldestBuildYear
            var client14 = _httpClientFactory.CreateClient();
            var responseMessage14 = await client14.GetAsync(url + "OldestBuildYear");
            var jsonData14 = await responseMessage14.Content.ReadAsStringAsync();
            ViewBag.OldestBuildYear = jsonData14;
            #endregion

            #region PassiveCategoryCount
            var client15 = _httpClientFactory.CreateClient();
            var responseMessage15 = await client15.GetAsync(url + "PassiveCategoryCount");
            var jsonData15 = await responseMessage15.Content.ReadAsStringAsync();
            ViewBag.PassiveCategoryCount = jsonData15;
            #endregion

            #region ProductCount
            var client16 = _httpClientFactory.CreateClient();
            var responseMessage16 = await client16.GetAsync(url + "ProductCount");
            var jsonData16 = await responseMessage16.Content.ReadAsStringAsync();
            ViewBag.ProductCount = jsonData16;
            #endregion


            return View();
        }
    }
}
