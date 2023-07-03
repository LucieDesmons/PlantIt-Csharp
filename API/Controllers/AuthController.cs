using BLL.Interfaces;
using DATA.DAL.Context;
using DATA.DTO;
using DATA.DTO.custom;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly PlantItContext _context;
        private readonly IRegisterService _registerService;
        private readonly IAuthenticationService _authenticationService;
        private readonly ILoginService _loginService;

        public AuthController(IConfiguration configuration,
                              PlantItContext context,
                              IRegisterService registerService,
                              IAuthenticationService authenticationService,
                              ILoginService loginService)
        {
            _configuration = configuration;
            _context = context;
            _registerService = registerService;
            _authenticationService = authenticationService;
            _loginService = loginService;
        }

        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] LoginModel login)
        {
            var existing_authentication = _loginService.Authenticate(login);
                
            if (existing_authentication == null || !BCrypt.Net.BCrypt.Verify(login.Password, existing_authentication.Password))
            {
                return Unauthorized();
            }

            var jwtSettings = _configuration.GetSection("JwtSettings");
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["Secret"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[] {
                new Claim(JwtRegisteredClaimNames.Sub, login.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var token = new JwtSecurityToken(
                issuer: jwtSettings["Issuer"],
                audience: jwtSettings["Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: credentials
            );

            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token),
                user = existing_authentication,
            });
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] RegisterModel model)
        {
            var existingUser = _context.Authentications.FirstOrDefault(u => u.Email == model.Email);
            if (existingUser != null)
            {
                return BadRequest("Username is already taken");
            }

            var user = _registerService.RegisterUser(model);

            var jwtSettings = _configuration.GetSection("JwtSettings");
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["Secret"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[] {
                new Claim(JwtRegisteredClaimNames.Sub, model.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var token = new JwtSecurityToken(
                issuer: jwtSettings["Issuer"],
                audience: jwtSettings["Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: credentials
            );

            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token),
                user = user.Result,
            });
        }

    }
}
