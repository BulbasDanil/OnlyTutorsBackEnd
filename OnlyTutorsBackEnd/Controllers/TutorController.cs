using Microsoft.AspNetCore.Mvc;
using OnlyTutorsBackEnd.Contracts;
using OnlyTutorsBackEnd.Models;

namespace OnlyTutorsBackEnd.Controllers
{
    [Route("api/tutors")]
    [ApiController]

    public class TutorController : ControllerBase
    {
        private ITutorRepository _tutorRepository;

        public TutorController(ITutorRepository tutorRepository)
        {
            _tutorRepository = tutorRepository;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetTutors()
        {
            try
            {
                var tutors = await _tutorRepository.GetTutors();
                if (tutors.Count() <= 0)
                    return NotFound();

                return Ok(tutors);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{tutorid}", Name = "GetTutorById")]
        public async Task<IActionResult> GetTutorById(int tutorid)
        {
            try
            {
                var tutor = await _tutorRepository.GetTutorById(tutorid);
                if (tutor == null)
                    return NotFound();

                return Ok(tutor);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("/tutors/search/", Name = "SearchForTutor")]
        public async Task<IActionResult> SearchForTutor(string searchString)
        {
            try
            {
                var tutors = await _tutorRepository.SearchForTutors(searchString);
                if (tutors == null)
                    return NotFound();

                return Ok(tutors);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> PostTutor(Tutor tutor)
        {
            try
            {
                if (await _tutorRepository.InsertTutor(tutor) == -1)
                    throw new Exception("Cannot insert tutor");

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> PutTutor(Tutor tutor)
        {
            try
            {
                if (await _tutorRepository.UpdateTutor(tutor, tutor.userId) == -1)
                    throw new Exception("Cannot update tutor");

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
