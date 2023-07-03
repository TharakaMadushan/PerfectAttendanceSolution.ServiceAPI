using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace PerfectAttendanceSolution.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        public static Users users = new Users();
        private readonly IAuthReporsitory _auth;
        private readonly DataContext _context;
        private readonly IConfiguration _configuration;

        public AuthController(IAuthReporsitory auth, DataContext context, IConfiguration configuration)
        {
            _auth = auth;
            _context = context;
            _configuration = configuration;
        }

        [HttpPost("register")]
        public async Task<ActionResult> Register(UserRegisterRequest request)
        {
            if (_context.Users.Any(u => u.SegmentID == request.SegmentID && u.EmployeeNo == request.EmployeeNo))
            {
                return BadRequest("User Already Registered!");
            }
            await _auth.AddUsers(request);
            return Ok("User Created!");
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLoginRequest request)
        {
            var loginUsers = await _auth.Login(request.SegmentID, request.DocumentEmployeeNo, request.Password);
            if (loginUsers == null)
            {
                return Unauthorized("User not found!");
            }

            string token = CreateToken(users);
            return Ok(token);
        }

        private string CreateToken(Users user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Role, "Admin")
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
                _configuration.GetSection("AppSettings:Token").Value));

            //var key  =  new SymmetricSecurityKey(Encoding.UTF8.GetBytes("this is my custom Secret key for authentication"));

            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);
            var token = new JwtSecurityToken(claims: claims, expires: DateTime.Now.AddDays(1), signingCredentials: cred);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }
    }
}