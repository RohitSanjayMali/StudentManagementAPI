using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentManagementAPI.Models;
using StudentManagementAPI.Services;

namespace StudentManagementAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        // GET: api/student
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var students = await _studentService.GetAllStudentsAsync();
            return Ok(students);
        }

        // GET: api/student/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByStudentIdAsync(int id)
        {
            var student = await _studentService.GetByStudentIdAsync(id);

            if (student == null)
            {
                return NotFound(new { message = "Student not found" }); // BUG FIX: was "Student is fount"
            }

            return Ok(student);
        }

        // POST: api/student
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Student student)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            student.CreatedDate = DateTime.UtcNow;

            await _studentService.AddAsync(student);

            return Ok(new
            {
                message = "Student added successfully",
                data = student
            });
        }

        // PUT: api/student/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Student student)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (id != student.Id)
                return BadRequest(new { message = "ID mismatch" });

            await _studentService.UpdateAsync(student);

            return Ok(new { message = "Student updated successfully" });
        }

        // DELETE: api/student/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _studentService.DeleteAsync(id);
            return Ok(new { message = "Student deleted successfully" });
        }
    }
}
