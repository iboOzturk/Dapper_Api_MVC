using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.DTOs.ContactDtos;
using RealEstate_Dapper_Api.Repositories.ContactRepositories;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IContactRepository _contactRepository;

        public ContactsController(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllContact()
        {
            var responseMessage=await _contactRepository.GetAllContactAsync();
            return Ok(responseMessage);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetContact(int id)
        {
            var responseMessage=await _contactRepository.GetByIdContactAsync(id);
            return Ok(responseMessage);
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetLast4Contact()
        {
            var result=await _contactRepository.GetLast4ContactAsync();
            return Ok(result);
        }
        [HttpPost]
        public  IActionResult CreateProduct(CreateContactDto createContactDto)
        {
             _contactRepository.CreateContactAsync(createContactDto);           
            return Ok("Başarılı bir şekilde eklendi");
        }
        [HttpDelete]
        public IActionResult DeleteContact(int id) 
        { 
            _contactRepository.DeleteContactAsync(id);  
            return Ok("Başarılı bir şekilde silindi");
        }
        
    }
}
