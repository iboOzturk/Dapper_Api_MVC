namespace RealEstate_Dapper_Api.DTOs.ServiceDtos
{
    public class GetByIdServiceDto
    {
        public int ServiceID { get; set; }
        public string ServiceName { get; set; }
        public bool ServiceStatus { get; set; }
    }
}
