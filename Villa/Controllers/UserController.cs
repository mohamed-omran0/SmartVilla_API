using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Villa.Model.DTO;
using Villa.Repository;

namespace Villa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiVersionNeutral]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository userRepository;

        public UserController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }
        [HttpPost("Login")]
        public async Task<IActionResult> login(LoginRequestDto dto)
        {
            var Login = await userRepository.login(dto);
            if (Login == null)
            {
                return BadRequest("Uncorrect UserName Or Passowrd :)");
            }
            return Ok(Login);
        }
        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegistrationRequestDto dto)
        {
            var reg = await userRepository.Register(dto);
            if (reg == null)
            {
                return BadRequest("Something went wrong");
            }
            return Ok("User was registered! Please login.");
        }
    }
}
