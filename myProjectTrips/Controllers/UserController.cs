using Common.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Service.Interfaces;
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
        private IConfiguration _configuration;

        public UserController(IUserService userService, IsExist<UserDto> isExist, IConfiguration configuration)
        {
            _userService = userService;
            _isExist = isExist;
            _configuration = configuration;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {
            try
            {
                var addedUser = await _userService.Add(registerDto);
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
                var token = GenerateToken(user);
                return Ok(new { Token = token });
            }

            return Unauthorized("שם משתמש או סיסמה שגויים");
        }

        private string GenerateToken(UserDto user)
        {
            var secret = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));

            var credentials = new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
            
            var claims = new[] {
            new Claim(ClaimTypes.NameIdentifier,user.UserId.ToString()),
            new Claim(ClaimTypes.Name,user.UserName),
            new Claim(ClaimTypes.Role,user.Role),
            new Claim(ClaimTypes.Email,user.UserEmail)
            };

            var token = new JwtSecurityToken(_configuration["Jwt:Issuer"], _configuration["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(15),
                signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}
