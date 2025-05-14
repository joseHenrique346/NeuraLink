using Arguments.Arguments.Registration.Login;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using NeuraLink.StandardAdmin;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace NeuraLink.Controllers.Registration.Login
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        [HttpPost("Login")]
        public IActionResult Login([FromBody] LoginRequest loginRequest)
        {
            var admin = AdminSeeder.Admin;

            if (loginRequest.Email != admin.Email || !BCrypt.Net.BCrypt.Verify(loginRequest.Password, admin.Password))
            {
                return Unauthorized(new { mensagem = "Email ou senha inválidos" });
            }

            var claims = new[]
            {
                new Claim(ClaimTypes.Name, admin.UserName),
                new Claim(ClaimTypes.Role, admin.IsAdmin ? "admin" : "user")
            };

            var chave = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("PR0J3T04P114UN1M4RTR4B4LH01NT3GR4D0R"));
            var creds = new SigningCredentials(chave, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: "NeuraLink.auth",
                audience: "NeuraLink",
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds);

            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

            return Ok(new { token = tokenString });
        }
    }
}