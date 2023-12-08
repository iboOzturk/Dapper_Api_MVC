using Dapper;
using RealEstate_Dapper_Api.DTOs.ContactDtos;
using RealEstate_Dapper_Api.DTOs.EmployeeDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.ContactRepositories
{
    public class ContactRepository : IContactRepository
    {
        private readonly Context _context;

        public ContactRepository(Context context)
        {
            _context = context;
        }

        public async void CreateContactAsync(CreateContactDto createContactDto)
        {
            string query = "insert into Contact (Name,Subject,Email,Message,SendDate)" +
                " values (@Name,@Subject,@Email,@Message,@SendDate)";
            var parameters = new DynamicParameters();
            parameters.Add("@Name", createContactDto.Name);
            parameters.Add("@Subject", createContactDto.Subject);
            parameters.Add("@Email", createContactDto.Email);
            parameters.Add("@Message", createContactDto.Message);
            parameters.Add("@SendDate", DateTime.Now);
           
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async void DeleteContactAsync(int id)
        {
            string query = "Delete from Contact where ContactID=@ContactID";
            var parameters = new DynamicParameters();
            parameters.Add("@ContactID", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<List<ResultContactDto>> GetAllContactAsync()
        {
            string query = "select * from Contact";
            using (var connection = _context.CreateConnection())
            {
                var response=await connection.QueryAsync<ResultContactDto>(query);
                return response.ToList();
            }
        }

        public async Task<GetByIdContactDto> GetByIdContactAsync(int id)
        {
            string query = "Select * from Contact where ContactID=@ContactID";
            var parametres = new DynamicParameters();
            parametres.Add("@ContactID", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<GetByIdContactDto>(query, parametres);
                return values;
            }
        }

        public async Task<List<ResultContactDto>> GetLast4ContactAsync()
        {
            string query = "select top(4) * from contact order by ContactID desc";
            using (var connection = _context.CreateConnection())
            {
                var response = await connection.QueryAsync<ResultContactDto>(query);
                return response.ToList();
            }
        }
    }
}
