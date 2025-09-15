using CMSystemWebApis.Dtos;
using CMSystemWebApis.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CMSystemWebApis.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController(IContactService service) : ControllerBase
    {
        private readonly IContactService _service = service;

        [HttpGet] 
        public async Task<IActionResult> GetAll()
        {
            var contacts =  await _service.GetAllContactsAsync();
            return Ok(contacts);
        }
        [HttpGet("paged")]
public async Task<IActionResult> GetPaged([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
{
    var contacts = await _service.GetPaginatedContactsAsync(page, pageSize);
    return Ok(contacts);
}


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var contact = await _service.GetContactByIdAsync(id);
            return contact is null ? NotFound() : Ok(contact);
        }
        [HttpPost] 
        public async Task<IActionResult> CreateContact([FromBody] ContactCreateDto contactCreateDto)
        {
            var createdContact = await _service.CreateContactAsync(contactCreateDto);
            return CreatedAtAction(nameof(GetById), new {id = createdContact.Id}, createdContact);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateContact(int id, [FromBody] ContactUpdateDto contactUpdateDto)
        {
            bool success = await _service.UpdateContactAsync(id, contactUpdateDto);
            if (success)
            {
                return NoContent();
            } else
            {
                return NotFound();
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContact(int id)
        {
            bool success = await _service.DeleteContactAsync(id);
            if (success)
            {
                return NoContent();
            } else
            {
                return NotFound();
            }
        }
    }
}
