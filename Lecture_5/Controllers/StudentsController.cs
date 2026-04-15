using Lecture_5.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Lecture_5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        
            private static List<Student> StudentsList = new List<Student> {
        new Student { Id = 1, FirstName = "Elene", LastName = "Nemstsveridze", age=20 },
        new Student { Id = 2, FirstName = "Elene", LastName = "Nemstsveridze", age=21 },
        new Student { Id = 3, FirstName = "Elene", LastName = "Nemstsveridze", age=22 },
        new Student { Id = 4, FirstName = "Elene", LastName = "Nemstsveridze", age=23 },
        new Student { Id = 5, FirstName = "Elene", LastName = "Nemstsveridze", age=24 },
    };
       

        // GET: api/<StudentsController>
        [HttpGet]
        public IEnumerable<Student> Get()
        {
            return StudentsList;
        }

        // GET api/<StudentsController>/5
        [HttpGet("{id}")]
        public Student? Get(int id)
        {
            return StudentsList.FirstOrDefault(x=>x.Id == id);
        }

        // POST api/<StudentsController>
        [HttpPost]
        public IEnumerable<Student> Post([FromBody] Student student)
        {
            StudentsList.Add(student);
            return StudentsList;
        }

        // PUT api/<StudentsController>/5
        [HttpPut("{id}")]
        public IEnumerable<Student> Put(int id, [FromBody] Student student)
        {
            var myStudent = StudentsList.FirstOrDefault(x => x.Id == id);
            myStudent.FirstName = student.FirstName;
            myStudent.LastName = student.LastName;
            myStudent.age = student.age;

            return StudentsList;
        }

        // DELETE api/<StudentsController>/5
        [HttpDelete("{id}")]
        public IEnumerable<Student> Delete(int id)
        {
            var myStudent = StudentsList.FirstOrDefault(x => x.Id == id);

            StudentsList.Remove(myStudent);
            return StudentsList;
        }
    }
}
