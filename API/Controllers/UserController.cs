using BLL.Services;
using DATA.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: api/users
        [HttpGet("users")]
        public ActionResult<List<UserDto>> GetAllUsers()
        {
            try
            {
                var users = _userService.GetAllUsers();
                return Ok(users);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // GET: api/users/{id}
        [HttpGet("{id}")]
        public ActionResult<UserDto> GetUserById(int id)
        {
            try
            {
                var user = _userService.GetUserById(id);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

       /* // POST: api/users
        [HttpPost("user")]
        public ActionResult<UserDto> CreateUser([FromBody] UserDto userDto)
        {
            try
            {
                var createdUser = _userService.CreateUser(userDto);
                return CreatedAtAction(nameof(GetUserById), new { id = createdUser.IdUser }, createdUser);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // PUT: api/users/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id, [FromBody] UserDto userDto)
        {
            try
            {
                if (id != userDto.IdUser)
                {
                    return BadRequest("User ID mismatch.");
                }

                var updatedUser = _userService.UpdateUser(userDto);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        } */

        // DELETE: api/users/{id}
       /* [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            try
            {
                _userService.DeleteUser(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        } */

      /*  // POST: api/users/botanist
        [HttpPost("botanist")]
        public ActionResult<UserDto> CreateBotanist([FromBody] UserDto userDto)
        {
            try
            {
                var createdBotanist = _userService.CreateBotanist(userDto);
                return CreatedAtAction(nameof(GetUserById), new { id = createdBotanist.IdUser }, createdBotanist);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        } */
    }
}