using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Student_Hobbies.Model;
using Student_Hobbies.Repository;

namespace Student_Hobbies.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HobbiesController : ControllerBase
    {
        private readonly IHobbiesRepository _hobbiesRepository;

        public HobbiesController(IHobbiesRepository hobbiesRepository)
        {
            _hobbiesRepository = hobbiesRepository;
        }
        // GET: api/Hobbies
        [HttpGet]
        public IEnumerable<ReturnModel> Get()
        {
            return _hobbiesRepository.GetAllHobbies();
        }

        // GET: api/Hobbies/5
        [HttpGet("{id}")]
        public ActionResult<Hobbies> Get(int id)
        {
            var hobby = _hobbiesRepository.GetHobbyById(id);
            if (hobby == null)
            {
                return NotFound();
            }
            return hobby;
        }

        // POST: api/Hobbies
        [HttpPost]
        [Route("create")]
        public ActionResult<Hobbies> Post([FromBody] Hobbies hobby)
        {
            _hobbiesRepository.AddHobby(hobby);
            //return CreatedAtAction(nameof(Get), new { id = hobby.Id }, hobby);
            return RedirectToAction("Index");
        }

        // PUT: api/Hobbies/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Hobbies hobby)
        {
            if (id != hobby.Id)
            {
                return BadRequest();    
            }

            try
            {
                _hobbiesRepository.UpdateHobby(hobby);
                return NoContent();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        // DELETE: api/Hobbies/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var hobbyToDelete = _hobbiesRepository.GetHobbyById(id);
            if (hobbyToDelete == null)
            {
                return NotFound();
            }
            _hobbiesRepository.DeleteHobby(id);
            return NoContent();
        }
    }
}
