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
        public ActionResult<IEnumerable<Student>> GetAll()
        {
            return Ok(_repo.GetAll());
        }

        // GET api/<StudentsController>/5
        [HttpGet("{id}")]
        public ActionResult<Student> GetById(int id)
        {
          var student = _repo.GetById(id);
                if (student == null) 
                return NotFound();
              
                return Ok(student);
        }

        // POST api/<StudentsController>
        [HttpPost]
        public ActionResult<Student> Post([FromBody] Student student)
        {
            if (student == null)
                return BadRequest();
            var added =_repo.Add(student);
            return Ok(added);
        }

        // PUT api/<StudentsController>/5
        [HttpPut("{id}")]
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
        public ActionResult<Student> Delete(int id)
        {
            var studentToRemove = _repo.GetById(id);
            if (studentToRemove == null)
                return NotFound();
            _repo.Delete(id);
            return Ok(studentToRemove);
        }
    }
}
