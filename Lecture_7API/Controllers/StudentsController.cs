using Lecture_7Application.DTOs;
using Lecture_7Application.Services;
using Microsoft.AspNetCore.Mvc;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Lecture_7API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        public readonly IStudentServices _studentService;
        public StudentsController(IStudentServices studentServices)
        {
            _studentService = studentServices;
        }

        // GET: api/<StudentsController>
        [HttpGet]
        [HttpGet]
        public async Task<IEnumerable<StudentsDTO>> Get()
        {
            return await _studentService.GetStudents();
        }


        // GET api/<StudentsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<StudentsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<StudentsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<StudentsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
