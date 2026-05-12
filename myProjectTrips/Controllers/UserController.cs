using Common.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using myProject_trips.Extensions;
using Service.Interfaces;
using Service.Services;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace myProject_trips.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IsExist<UserDto> _isExist;
        private readonly TokenService _tokenService;

        public UserController(IUserService userService, IsExist<UserDto> isExist, TokenService tokenService)
        {
            _userService = userService;
            _isExist = isExist;
            _tokenService = tokenService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {
            try
            {
                var addedUser = await _userService.Register(registerDto);
                return Ok(addedUser);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            var user = await _isExist.Exist(loginDto);

            if (user != null)
            {
                var token = _tokenService.GenerateToken(user);
                return Ok(new {
                    Token = token,
                    Username = user.UserName,
                    role = user.Role
                });
            }

            return Unauthorized("שם משתמש או סיסמה שגויים");
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var users = await _userService.GetAll();
            return Ok(users);
        }

        [Authorize]
        [HttpGet("my-trips")]
        public async Task<IActionResult> GetMyTrips()
        {
            var currentUser = User.GetUserDetails();
            if (currentUser == null) return Unauthorized();

            var trips = await _userService.GetUserTrips(currentUser.UserId);

            return Ok(trips);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var user = await _userService.GetById(id);
            if (user == null)
            {
                return NotFound($"משתמש עם מזהה {id} לא נמצא במערכת.");
            }
            return Ok(user);
        }

        [HttpPost]
        //public async Task<ActionResult> CreateUser([FromBody] UserDto newUser)
        //{
        //    if (newUser == null)
        //    {
        //        return BadRequest("Missing user data");
        //    }
        //    var createdUser = await _userService.Add(newUser);

        //    return CreatedAtAction(nameof(Get), new { id = createdUser.UserId }, createdUser);
        //}

        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UserDto userDto)
        {
            if (id != userDto.UserId)
            {
                return BadRequest("מזהה המשתמש אינו תואם.");
            }

            var result = await _userService.Update(id, userDto);
            if (result == null)
            {
                return NotFound("משתמש לא נמצא.");
            }

            return NoContent();
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existingUser = await _userService.GetById(id);
            if (existingUser == null)
            {
                return NotFound($"משתמש עם מזהה {id} לא נמצא במערכת");
            }

            await _userService.Delete(id);
            return NoContent();
        }
    }
}
