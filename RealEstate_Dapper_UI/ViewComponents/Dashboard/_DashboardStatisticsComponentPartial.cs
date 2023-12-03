using Microsoft.AspNetCore.Mvc;

namespace RealEstate_Dapper_UI.ViewComponents.Dashboard
{
    public class _DashboardStatisticsComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        string url = "https://localhost:44383/api/Statistics/";

        public _DashboardStatisticsComponentPartial(IHttpClientFactory httpClientFactory)   
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            #region EmployeeNameByMaxProductCount
            var client11 = _httpClientFactory.CreateClient();
            var responseMessage11 = await client11.GetAsync(url + "EmployeeNameByMaxProductCount");
            var jsonData11 = await responseMessage11.Content.ReadAsStringAsync();
            ViewBag.EmployeeNameByMaxProductCount = jsonData11;
            #endregion

            #region ActiveEmployeeCount
            var client2 = _httpClientFactory.CreateClient();
            var responseMessage2 = await client2.GetAsync(url + "ActiveEmployeeCount");
            var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
            ViewBag.ActiveEmployeeCount = jsonData2;
            #endregion

            #region ProductCount
            var client16 = _httpClientFactory.CreateClient();
            var responseMessage16 = await client16.GetAsync(url + "ProductCount");
            var jsonData16 = await responseMessage16.Content.ReadAsStringAsync();
            ViewBag.ProductCount = jsonData16;
            #endregion

            #region DifferentCityCount
            var client10 = _httpClientFactory.CreateClient();
            var responseMessage10 = await client10.GetAsync(url + "DifferentCityCount");
            var jsonData10 = await responseMessage10.Content.ReadAsStringAsync();
            ViewBag.DifferentCityCount = jsonData10;
            #endregion

            return View();
        }
    }
}
