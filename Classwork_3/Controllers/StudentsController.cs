using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Classwork_3.Data;
using Classwork_3.Models;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Classwork_3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public StudentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/<StudentsController>
        [HttpGet]
        public ActionResult<IEnumerable<Student>> Get()
        {
            return _context.Students.ToList();
        }

        // GET api/<StudentsController>/5
        [HttpGet("{id}")]
        public ActionResult<Student> Get(int id)
        {
            var matchedStudent = _context.Students.FirstOrDefault(x => x.Id == id);

            if (matchedStudent == null)
            {
                return NotFound();
            }

            return matchedStudent;
        }

        // POST api/<StudentsController>
        [HttpPost]
        public ActionResult<IEnumerable<Student>> Post([FromBody] StudentCreateDto dto)
        {
            var student = new Student
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Age = dto.Age
            };


            _context.Students.Add(student);
            _context.SaveChanges();

            return _context.Students.ToList();
        }

        // PUT api/<StudentsController>/5
        [HttpPut("{id}")]
        public ActionResult<Student> Put(int id, [FromBody] StudentCreateDto dto)
        {
            var student = _context.Students.FirstOrDefault(x => x.Id == id);

            if(student == null)
            {
                return NotFound();
            }

            student.FirstName = dto.FirstName;
            student.LastName = dto.LastName;
            student.Age = dto.Age;

            _context.SaveChanges();
            return student;

        }

        // DELETE api/<StudentsController>/5
        [HttpDelete("{id}")]
        public ActionResult<IEnumerable<Student>> Delete(int id)
        {
            var matchedstudent = _context.Students.FirstOrDefault(x => x.Id == id);
            if(matchedstudent == null)
            {
                return NotFound();
            }

            _context.Remove(matchedstudent);
            _context.SaveChanges();
            return _context.Students.ToList();
        }
    }
}
