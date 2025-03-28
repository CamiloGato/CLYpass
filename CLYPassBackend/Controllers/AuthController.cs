using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using CLYPassBackend.Data;
using CLYPassBackend.Dtos;
using CLYPassBackend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BCrypt.Net;

namespace CLYPassBackend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController(AppDbContext context, IConfiguration config) : ControllerBase
{
    private readonly AppDbContext _context = context;
    private readonly IConfiguration _config = config;

    [HttpPost("Login")]
    public async Task<IActionResult> Login([FromBody] LoginDto dto)
    {
        User? user = await _context.Users.FirstOrDefaultAsync(u => u.Email == dto.Email);
        if (user is null || !BCrypt.Net.BCrypt.Verify(dto.Password, user.PasswordHash))
        {
            return Unauthorized(new { message = "Invalid credentials." });
        }

        string token = GenerateJwt(user);

        return Ok(new { token });
    }

    [HttpPost("Register")]
    public async Task<IActionResult> Register([FromBody] RegisterDto dto)
    {
        if (await _context.Users.AnyAsync(u => u.Email == dto.Email))
        {
            return Conflict(new { message = "Email already registered." });
        }

        var user = new User
        {
            Name = dto.Name,
            Email = dto.Email,
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password)
        };

        _context.Users.Add(user);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(Register), new { id = user.Id }, new { user.Id, user.Name, user.Email });
    }

    private string GenerateJwt(User user)
    {
        IConfigurationSection jwtSettings = _config.GetSection("JwtSettings");
        string secretKey = jwtSettings["SecretKey"]!;
        string? issuer = jwtSettings["Issuer"];
        string? audience = jwtSettings["Audience"];
        int expiryMinutes = Convert.ToInt32(jwtSettings["ExpiryMinutes"]);

        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
            new Claim(JwtRegisteredClaimNames.Email, user.Email),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim("name", user.Name)
        };

        SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
        SigningCredentials creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        JwtSecurityToken token = new JwtSecurityToken(
            issuer: issuer,
            audience: audience,
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(expiryMinutes),
            signingCredentials: creds
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}