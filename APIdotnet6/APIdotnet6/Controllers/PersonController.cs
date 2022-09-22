using APIdotnet6.Model;
using APIdotnet6.Services;
using Microsoft.AspNetCore.Mvc;

namespace APIdotnet6.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : ControllerBase
    {
        
        private readonly ILogger<PersonController> _logger;
        private IPerson _iperson;
        public PersonController(ILogger<PersonController> logger, IPerson person)
        {
            _logger = logger;
            _iperson = person;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_iperson.FindAll());
        }
        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var person = _iperson.FindById(id);
            if (person == null) return NotFound();
            return Ok(person);

        }
        [HttpPost]
        public IActionResult Post([FromBody] Person person)
        {
            if (person == null) return BadRequest();
            return Ok(_iperson.Create(person));
        }

        [HttpPut]
        public IActionResult Put([FromBody] Person person)
        {
            if (person == null) return BadRequest();
            return Ok(_iperson.Update(person));
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            _iperson.Delete(id);
            return NoContent();
        }

    }
}