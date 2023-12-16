using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.DTOs.ToDoListDtos;
using RealEstate_Dapper_Api.Repositories.ToDoListRepositories;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoListsController : ControllerBase
    {
        private readonly IToDoListRepository _toDoListRepository;

        public ToDoListsController(IToDoListRepository toDoListRepository)
        {
            _toDoListRepository = toDoListRepository;
        }

        [HttpGet]
        public async Task<IActionResult> ToDoList()
        { 
            var values=await _toDoListRepository.GetAllToDoListAsync();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateToDoList(CreateToDoListDto createToDoListDto)
        {
             _toDoListRepository.CreateToDoList(createToDoListDto);
            return Ok("Başarılı bir şekilde oluşturuldu");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteToDoList(int id)
        {
            _toDoListRepository.DeleteToDoList(id);
            return Ok("Başarılı bir şekilde silindi");
        }
        [HttpPut]
        public IActionResult UpdateTodoList(UpdateToDoListDto updateToDoListDto)
        {
            _toDoListRepository.UpdateToDoList(updateToDoListDto);
            return Ok("Başarılı bir şekilde güncellendi");
        }
    }
}
