using c_sharp_api_starter.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using models;
using System.Diagnostics;

namespace c_sharp_api_starter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : BaseController
    {
        [HttpPost("login")]
        public ResponseResult<string> Login(Login login)
        {
            // User user = userService.Login(user);
            User user = new User() { Id = 1, Email = login.Email }; // for debug
            string token = new JwtGenerator().GenerateToken(user.Id, user.Email);
            return ResponseResult<string>.Success(token);
        }

        [HttpPost("register")]
        public ResponseResult<string> Register(Register register)
        {
            // User user = userService.Register(user);
            User user = new User() { Id = 1, Email = register.Email }; // for debug
            string token = new JwtGenerator().GenerateToken(user.Id, user.Email);
            return ResponseResult<string>.Success(token);
        }
    }
}
