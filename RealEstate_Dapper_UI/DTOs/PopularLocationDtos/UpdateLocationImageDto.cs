namespace RealEstate_Dapper_UI.DTOs.PopularLocationDtos
{
    public class UpdateLocationImageDto
    {
        public int LocationID { get; set; }

        public string CityName { get; set; }
        public IFormFile ImageUrl { get; set; }
    }
}
