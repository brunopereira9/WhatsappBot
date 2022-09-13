using Microsoft.AspNetCore.Mvc;
using WhatsappBot.Business.Interfaces;
using WhatsappBot.Entities;
using WhatsappBot.Repositories.Interfaces;

namespace WhatsappBot.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private readonly IPeopleRepository _peopleRepository;
        private readonly IPeopleBusiness _peopleBusiness;
        
        public PeopleController(IPeopleRepository peopleRepository, IPeopleBusiness peopleBusiness)
        {
            _peopleRepository = peopleRepository;
            _peopleBusiness = peopleBusiness;
        }
        
        // GET: api/People/5
        [HttpGet("Id/{id}")]
        public ActionResult<PeopleEntity> GetById(int id)
        {
            try{
                var contact = _peopleRepository.GetById(id);
                if (contact == null)
                {
                    return NotFound();
                }

                return Ok(contact);
            }catch(Exception e){
                return BadRequest(e.Message);
            }
        }
        
        // GET: api/People/validate-all
        [HttpGet("validate-all/{sessionName}")]
        public async Task<ActionResult<List<PeopleEntity>>> ValidateAll(string sessionName)
        {
            try{
                var peoples = await _peopleBusiness.ValidateAll(sessionName);
                if (!peoples.Any())
                    return NotFound();

                return Ok(peoples);
            }catch(Exception e){
                return BadRequest(e.Message);
            }
        }
        
    }
}
