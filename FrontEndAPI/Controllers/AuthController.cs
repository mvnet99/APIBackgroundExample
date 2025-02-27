using FrontEndAPI.Models;
using FrontEndAPI.Services;
using Microsoft.AspNetCore.Mvc;


namespace FrontEndAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IJwtService _jwtService;
        private readonly ILogger<AuthController> _logger;

        // Simulated user database (in a real app, use a proper database)
        private readonly List<UserModel> _users = new List<UserModel>
        {
            new UserModel { Username = "admin", Role = "Admin" },
            new UserModel { Username = "user", Role = "User" }
        };

        public AuthController(IJwtService jwtService, ILogger<AuthController> logger)
        {
            _jwtService = jwtService;
            _logger = logger;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginModel login)
        {
            _logger.LogInformation("Login attempt for user: {Username}", login.Username);

            // In a real app, validate credentials against a database
            // This is a simplified example with hardcoded passwords
            if (login.Username == "admin" && login.Password == "admin123")
            {
                var user = _users.First(u => u.Username == login.Username);
                var token = _jwtService.GenerateToken(user);

                return Ok(new { token });
            }
            else if (login.Username == "user" && login.Password == "user123")
            {
                var user = _users.First(u => u.Username == login.Username);
                var token = _jwtService.GenerateToken(user);

                return Ok(new { token });
            }

            return Unauthorized(new { message = "Invalid username or password" });
        }
    }
}
