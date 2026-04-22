using Lecture_6.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Lecture_6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {

        private static List<Student> students = new List<Student>
        {
            new Student { Id = 1, Name = "Giorgi", GroupId = 11 },
            new Student { Id = 2, Name = "Nino", GroupId = 12 },
            new Student { Id = 3, Name = "Luka", GroupId = 11 }
        };

        // GET: api/<StudentsController>
        [HttpGet]
        public IEnumerable<Student> Get()
        {
            return students;
        }

        //[HttpGet("get2")]
        //public IEnumerable<string> Get1()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        [HttpGet("group/{groupid}")]
        public IEnumerable<Student> Get1(int groupid)
        {

            return students.FindAll(x => x.GroupId == groupid);
        }

        [HttpGet("search")]
        public Student? Get2(string name)
        {

            return students.FirstOrDefault(x => x.Name == name);
        }


        //[HttpGet("get2/getget")]
        //public string Get1(string name, string lastname)
        //{
        //    return name;
        //}

        //[HttpGet("get3/{name}")]
        //public string Get1(string name)
        //{
        //    return name;

        //}

        // GET api/<StudentsController>/5
        [HttpGet("{id}")]
        public Student? Get(int id)
        {
            return students.FirstOrDefault(x => x.Id == id);
        }

        // POST api/<StudentsController>
        [HttpPost]
        public IEnumerable<Student> Post([FromBody] Student newStudent)
        {
            students.Add(newStudent);
            return students;
        }

        //[HttpPost("post1")]
        //public void Post1([FromQuery] string value)
        //{
        //}

        // PUT api/<StudentsController>/5
        [HttpPut("{id}")]
        public IEnumerable<Student> Put(int id, [FromBody] Student updatedStudent)
        {
            var myStudent = students.FirstOrDefault(x=>x.Id == id);

            myStudent.Name = updatedStudent.Name;
            myStudent.GroupId = updatedStudent.GroupId;
            return students;
        }

        // DELETE api/<StudentsController>/5
        [HttpDelete("{id}")]
        public IEnumerable<Student> Delete(int id)
        {
            var myStudent = students.FirstOrDefault(x=>x.Id==id);
            students.Remove(myStudent);

            return students;
        }
    }
}
