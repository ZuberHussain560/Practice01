using LoginAPI.APIContext;
using LoginAPI.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System;
using System.Threading.Tasks;
using System.Linq;

namespace LoginAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly LoginContext _context;

        public UserController(LoginContext context)
        {
            _context = context;
        }


        [HttpPost("register")]
        public IActionResult Register([FromBody] User user)
        {
            var existingUser = _context.Users.FirstOrDefault(u => u.Email == user.Email);

            if (existingUser != null)
            {
                return BadRequest("Email is already registered");
            }

            _context.Users.Add(user);
            _context.SaveChanges();

            return Ok("Registration successful");
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] User user)
        {
            var existingUser = _context.Users.FirstOrDefault(u => u.Email == user.Email && u.Password == user.Password);

            if (existingUser == null)
            {
                return Unauthorized("Invalid email or password");
            }

            return Ok("Login successful");
        }
    }
}
