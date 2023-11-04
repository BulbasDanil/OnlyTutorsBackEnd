using Microsoft.AspNetCore.Mvc;
using OnlyTutorsBackEnd.Contracts;
using OnlyTutorsBackEnd.Models;

namespace OnlyTutorsBackEnd.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            try
            {
                var users = await _userRepository.GetUsers();
                return Ok(users);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> PostUser()
        {
            try
            {
                User a = new User()
                {
                    Id = 123,
                    Name = "Zalupkin",
                    Surname = "Pivkin",
                    Email = "123@gmail.com",
                    PhoneNumber = "1337",
                    Password = "123",
                    DateOfBirth = DateTime.Now,
                    Rating = 4.5f
                };

                await _userRepository.InsertUser(a);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
