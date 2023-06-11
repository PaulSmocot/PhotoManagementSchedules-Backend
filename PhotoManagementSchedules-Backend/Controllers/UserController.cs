using Microsoft.AspNetCore.Mvc;

using PhotoManagementSystem.Application.Interfaces;
using PhotoManagementSystem.Application.Models.UserDtos;

namespace PhotoManagementSchedules_Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserRegisterDto userDto)
        {
            try
            {
                var userId = await userService.Register(userDto);

                return Ok(userId);
            }
            catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet, Route("{id}")]
        public async Task<IActionResult> GetUserById(Guid id)
        {
            var user = await userService.GetUserById(id);
            return Ok(user);
        }

        [HttpDelete, Route("{id}")]
        public async Task<IActionResult> DeleteUserById(Guid id)
        {
            await userService.DeleteUserById(id);

            return NoContent();
        }

        [HttpPost, Route("login")]
        public async Task<IActionResult> Login(UserLoginDto userLoginDto)
        {
            var userLoginResponse = await userService.Login(userLoginDto);

            return Ok(userLoginResponse);
        }

        [HttpPut, Route("{id}")]
        public async Task<IActionResult> UpdateUser(UserDto userDto, Guid id)
        {
            var userId = await userService.UpdateUser(userDto, id);

            return Ok(userId);
        }
    }
}