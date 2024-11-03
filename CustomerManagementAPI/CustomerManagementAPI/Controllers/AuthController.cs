using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using CustomerManagement.DTO;
using CustomerManagement.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace CustomerManagementAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController : ControllerBase
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IConfiguration _configuration;

    public AuthController(UserManager<ApplicationUser> userManager, IConfiguration configuration)
    {
        _userManager = userManager;
        _configuration = configuration;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginDTO model)
    {
        var user = await _userManager.FindByNameAsync(model.Username);
        if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
        {
            // Get the user's roles
            var roles = await _userManager.GetRolesAsync(user);

            // Generate the token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                        new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(ClaimTypes.Email, user.Email),
                        new Claim(ClaimTypes.Role, roles.FirstOrDefault() ?? "User")
                    }),
                Expires = DateTime.UtcNow.AddHours(1),
                Issuer = _configuration["Jwt:Issuer"],
                Audience = _configuration["Jwt:Audience"],
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return Ok(new { Token = tokenHandler.WriteToken(token) });
        }

        return Unauthorized(new { Message = "Invalid credentials" });
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterDTO model)
    {
        var user = new ApplicationUser { MiddleName = model.MiddleName, Email = model.Email, FirstName = model.FirstName, LastName = model.LastName };
        var result = await _userManager.CreateAsync(user, model.Password);

        if (result.Succeeded)
        {
            await _userManager.AddToRoleAsync(user, "User");
            return Ok(new { Message = "User registered successfully" });
        }

        return BadRequest(result.Errors);
    }

    [HttpPost("logout")]
    public async Task<IActionResult> Logout()
    {
        return Ok(new { message = "Successfully logged out. Please delete the token from client storage." });
    }
}

