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
        public async Task<IEnumerable<StudentsDTO>> Get()
        {
            return await _studentService.GetStudents();
        }


        // GET api/<StudentsController>/5
        [HttpGet("{id}")]
        public async Task<StudentsDTO> Get(int id)
        {
            var student = _studentService.GetStudentById(id);
            if (student is null)
            {
                return null;
            }
            else
            {
                return await student;
            }
                
        }

        // POST api/<StudentsController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateStudentDTO dto)
        {
            var result = await _studentService.AddStudent(dto);
            return Created("", result);
        }

        // PUT api/<StudentsController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] CreateStudentDTO dto)
        {
            var result = await _studentService.UpdateStudent(id, dto);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        // DELETE api/<StudentsController>/5
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _studentService.DeleteStudent(id);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }
    }
}
