using Microsoft.AspNetCore.Mvc;
using StudentAPI.Models;
using StudentAPI.Repositories;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StudentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentRepositoryList _repo;

        public StudentsController(IStudentRepositoryList repo)
        {

            _repo = repo;
        }

        // GET: api/<StudentsController>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<Student>> GetAll()
        {
            return Ok(_repo.GetAll());
        }

        // GET api/<StudentsController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public ActionResult<Student> GetById(int id)
        {
          var student = _repo.GetById(id);
                if (student == null) 
                return NotFound();
              
                return Ok(student);
        }

        // POST api/<StudentsController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public ActionResult<Student> Post([FromBody] Student student)
        {
            if (student == null)
                return BadRequest();
            var added =_repo.Add(student);
            //return Ok(added);
            return CreatedAtAction(nameof(GetById), new { id = added.Id }, added);
        }

        // PUT api/<StudentsController>/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public ActionResult<Student> Put(int id, [FromBody] Student student)
        {
            var studentToUpdate = _repo.GetById(id);
            if (studentToUpdate == null)
                return BadRequest();
            studentToUpdate.Name = student.Name;
            studentToUpdate.YearOfBirth = student.YearOfBirth;
            return Ok(studentToUpdate);


        }

        // DELETE api/<StudentsController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public ActionResult<Student> Delete(int id)
        {
            var studentToRemove = _repo.GetById(id);
            if (studentToRemove == null)
                return NotFound();
            _repo.Delete(id);
            return Ok(studentToRemove);
        }
        // GET: api/students?birthYearAfter=2000&birthYearBefore=2005&sortBy=name
        [HttpGet("filtering/sorting")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<Student>> GetAll(
            [FromQuery] int? birthYearAfter,
            [FromQuery] int? birthYearBefore,
            [FromQuery] string? sortBy)
        {
            var students = _repo.GetAll(birthYearAfter, birthYearBefore, sortBy);
            return Ok(students);
        }

    }
}
