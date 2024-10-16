using ContactManagementApp.Models;
using ContactManagementApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace ContactManagementApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactManagement : ControllerBase
    {
        private readonly IContactService _contactService;

        public ContactManagement(IContactService contactService)
        {
            _contactService = contactService;
        }
        // GET api/ContactManagement
        [HttpGet]
        public IActionResult Get()
        {
            var contacts = _contactService.Get();
            return Ok(contacts);
        }

        // GET api/ContactManagement/{id}
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var contact = _contactService.GetContactById(id);
            if (contact == null) return NotFound(new { message = $"Contact with ID {id} not found." });

            return Ok(contact);
        }
        // POST api/ContactManagement
        [HttpPost]
        public IActionResult Post([FromBody] Contact contact)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdContact = _contactService.CreateContact(contact);
            return Ok(new { message = "Contact created successfully", contact = createdContact });
        }

        // PUT api/ContactManagement/{id}
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Contact contact)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var updatedContact = _contactService.UpdateContact(id, contact);
            if (updatedContact == null) return NotFound(new { message = $"Contact with ID {id} not found." });

            return Ok(new { message = "Contact updated successfully", contact = updatedContact });
        }

        // DELETE api/ContactManagement/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var isDeleted = _contactService.DeleteContact(id);
            if (!isDeleted) return NotFound(new { message = $"Contact with ID {id} not found." });

            return Ok(new { message = $"Contact with ID {id} deleted successfully." });
        }
    }
}
