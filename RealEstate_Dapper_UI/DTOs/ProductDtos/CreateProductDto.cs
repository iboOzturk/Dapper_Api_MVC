namespace RealEstate_Dapper_UI.DTOs.ProductDtos
{
    public class CreateProductDto
    {
        public string title { get; set; }
        public decimal price { get; set; }
        public string type { get; set; }
        public string coverImage { get; set; }
        public string city { get; set; }
        public string district { get; set; }
        public string address { get; set; }
        public string description { get; set; }
        public int productCategory { get; set; } 
        public int employeeId { get; set; }
        public bool DealOfTheDay { get; set; }

    }
}
