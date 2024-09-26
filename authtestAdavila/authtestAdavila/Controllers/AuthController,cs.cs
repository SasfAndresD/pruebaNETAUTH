using authtestAdavila.Service;
using authtestAdavila.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace authtestAdavila.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserService _userService;
        private readonly TokenService _tokenService;

        public AuthController(UserService userService, TokenService tokenService)
        {
            _userService = userService;
            _tokenService = tokenService;
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public IActionResult Login(LoginModel model)
        {
            var user = _userService.Authenticate(model.Username, model.Password);

            if (user == null)
                return Unauthorized();

            var token = _tokenService.GenerateToken(user);
            return Ok(new { token });
        }
    }
}
public class LoginModel
{
    public string Username { get; set; }
    public string Password { get; set; }
}