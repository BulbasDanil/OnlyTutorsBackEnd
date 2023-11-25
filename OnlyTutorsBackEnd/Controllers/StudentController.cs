using Microsoft.AspNetCore.Mvc;
using OnlyTutorsBackEnd.Contracts;
using OnlyTutorsBackEnd.Models;

namespace OnlyTutorsBackEnd.Controllers
{
    [Route("api/students")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private IStudentRepository _studentRepository;
        public StudentController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }


        [HttpGet("")]
        public async Task<IActionResult> GetUsers()
        {
            try
            {
                var students = await _studentRepository.GetStudents();
                if (students.Count() <= 0)
                    return NotFound();

                return Ok(students);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{lessondId}", Name ="GetStudentByLessonId")]
        public async Task<IActionResult> GetStudentsByLesson(int lessondId)
        {
            try
            {
                var students = await _studentRepository.GetStudentsByLesson(lessondId);
                if (students.Count() <= 0)
                    return NotFound();

                return Ok(students);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> PostStudent(Student student)
        {
            try
            {
                if (await _studentRepository.InsertStudent(student) == -1)
                    throw new Exception("Cannot insert student");

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> PutStudent(Student student)
        {
            try
            {
                if (await _studentRepository.UpdateStudent(student, student.userId) == -1)
                    throw new Exception("Cannot update student");

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
