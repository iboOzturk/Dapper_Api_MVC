using Dapper;
using RealEstate_Dapper_Api.DTOs.ToDoListDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.ToDoListRepositories
{
    public class ToDoListRepository : IToDoListRepository
    {
        private readonly Context _context;

        public ToDoListRepository(Context context)
        {
            _context = context;
        }

        public async void CreateToDoList(CreateToDoListDto createToDoListDto)
        {
            string query = "insert into ToDoList (Description,ToDoListStatus)" +
                " values (@Description,@ToDoListStatus)";
            var parameters = new DynamicParameters();
            parameters.Add("@Description", createToDoListDto.Description);
            parameters.Add("@ToDoListStatus",false);          
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async void DeleteToDoList(int id)
        {
            string query = "Delete from ToDoList where ToDoListID=@ToDoListID";
            var parameters = new DynamicParameters();
            parameters.Add("@ToDoListID", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<List<ResultToDoListDto>> GetAllToDoListAsync()
        {
            string query = "Select * from ToDoList";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultToDoListDto>(query);
                return values.ToList();
            }
        }

        public async void UpdateToDoList(UpdateToDoListDto updateToDoListDto)
        {
            string query = "Update ToDoList " +
                "set Description=@Description,ToDoListStatus=@ToDoListStatus " +
                "where ToDoListID=@ToDoListID ";
            var parameters = new DynamicParameters();
            parameters.Add("@Description", updateToDoListDto.Description);
            parameters.Add("@ToDoListStatus", updateToDoListDto.ToDoListStatus);         
            parameters.Add("@ToDoListID", updateToDoListDto.ToDoListID);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
