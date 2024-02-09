using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Student_Hobbies.Model;
using Student_Hobbies.Repository;

namespace Student_Hobbies.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentRepository _studentRepository;

        public StudentController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }
        // GET: api/Students
        [HttpGet]
        public IEnumerable<Student> Get()
        {
            return _studentRepository.GetAllStudents();
        }

        // GET: api/Students/5
        [HttpGet("{id}")]
        public ActionResult<Student> Get(int id)
        {
            var student = _studentRepository.GetStudentById(id);
            if (student == null)
            {
                return NotFound();
            }
            return student;
        }

        // POST: api/Students
        [HttpPost]
        public ActionResult<Student> Post([FromBody] Student student)
        {
            _studentRepository.AddStudent(student);
            return CreatedAtAction(nameof(Get), new { id = student.StudentId }, student);
        }

        // PUT: api/Students/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Student student)
        {
            if (id != student.StudentId)
            {
                return BadRequest();
            }

            try
            {
                _studentRepository.UpdateStudent(student);
                return NoContent();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        // DELETE: api/Students/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var studentToDelete = _studentRepository.GetStudentById(id);
            if (studentToDelete == null)
            {
                return NotFound();
            }
            _studentRepository.DeleteStudent(id);
            return NoContent();
        }
    }
}
