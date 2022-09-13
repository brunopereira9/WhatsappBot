using Microsoft.AspNetCore.Mvc;
using WhatsappBot.Dto;
using WhatsappBot.Entities;
using WhatsappBot.Interfaces;

namespace WhatsappBot.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactRepository _repository;
        public ContactController(IContactRepository repository)
        {
            _repository = repository;
        }

        // GET: api/Product
        [HttpGet]
        public ActionResult<IEnumerable<ContactEntity>> GetAll()
        {
            try{
                var contacts = _repository.GetAll();
                if (!contacts.Any())
                {
                    return NotFound();
                }

                return Ok(contacts);
            }catch(Exception e){
                return BadRequest(e.Message);
            }
        }

        // GET: api/Product/5
        [HttpGet("Id/{id}")]
        public ActionResult<ContactEntity> GetById(int id)
        {
            try{
                var contact = _repository.GetById(id);
                if (contact == null)
                {
                    return NotFound();
                }

                return Ok(contact);
            }catch(Exception e){
                return BadRequest(e.Message);
            }
        }
        // GET: api/Product/5
        [HttpGet("Name/{name}")]
        public ActionResult<ContactEntity> GetByName(string name)
        {
            try{
                var contact = _repository.GetByName(name);
                if (contact == null)
                {
                    return NotFound();
                }

                return Ok(contact);
            }catch(Exception e){
                return BadRequest(e.Message);
            }
        }

        

        // POST: api/Product
        [HttpPost]
        public ActionResult<ContactEntity> Insert(ContactDto contactDto)
        {
            try{
                if(contactDto.Name.Length < 3){
                    return BadRequest("Name length must be at least 3 characters long.");
                }
                
                var contact = new ContactEntity(contactDto.Name, contactDto.Phone, contactDto.IsPrivate);
                
                contact.SetMessageStock(contactDto.Message);
                _repository.Insert(contact);

                return CreatedAtAction("Insert", new { name = contact.Name }, contact);
                
            }catch(Exception e){
                return BadRequest(e.Message);
            }
        }

        // DELETE: api/Product/5
        [HttpDelete("{id}")]
        public IActionResult DeleteContact(int id)
        {
            try{
                var contact = _repository.GetById(id);
                
                if (contact == null)
                {
                    return NotFound();
                }

                _repository.Remove(contact);

                return Ok();
            }catch(Exception e){
                return BadRequest(e.Message);
            }
        }
    }
}
