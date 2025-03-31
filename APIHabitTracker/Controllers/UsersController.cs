using HabitTrackerAPI.Data;
using HabitTrackerAPI.Models;
using HabitTrackerAPI.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace HabitTrackerAPI.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;

        public UsersController(ApplicationDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        // Get all users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        [HttpPost("register")]
        public async Task<ActionResult<User>> RegisterUser([FromBody] UserRegisterDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Password))
                return BadRequest("Password cannot be empty.");

            var emailValidator = new EmailAddressAttribute();
            if (!emailValidator.IsValid(dto.Email))
                return BadRequest("Invalid email format.");

            var domainPart = dto.Email?.Split('@').ElementAtOrDefault(1);
            if (domainPart == null || !domainPart.Contains('.'))
                return BadRequest("Email must contain a valid domain with a dot (e.g., .com, .org)");

            if (await _context.Users.AnyAsync(u => u.Username == dto.Username))
                return BadRequest("Username already exists.");

            if (await _context.Users.AnyAsync(u => u.Email == dto.Email))
                return BadRequest("Email already in use.");

            var hashedPassword = HashPassword(dto.Password);

            var user = new User
            {
                Username = dto.Username,
                PasswordHash = hashedPassword,
                Email = dto.Email
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetUsers), new { id = user.Id }, user);
        }

        // User login with JWT authentication
        [HttpPost("login")]
        public async Task<ActionResult<string>> LoginUser([FromBody] UserLoginDto loginDto)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == loginDto.Username);
            if (user == null || !VerifyPassword(loginDto.Password, user.PasswordHash ?? string.Empty))
            {
                return Unauthorized("Invalid username or password");
            }

            // Generate JWT token
            string token = GenerateJwtToken(user);
            return Ok(new { Token = token });
        }

        // Hash password using SHA256
        private string HashPassword(string? password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password ?? string.Empty));
                return Convert.ToBase64String(hashedBytes);
            }
        }

        // Verify password against hash
        private bool VerifyPassword(string? password, string storedHash)
        {
            string hashedInput = HashPassword(password);
            return hashedInput == storedHash;
        }

        // Generate JWT token for authentication
        private string GenerateJwtToken(User user)
        {
            var jwtKey = _configuration["Jwt:Key"] ?? "ThisIsASuperSecretJwtKeyThatIsLongEnough!"; // fallback
            var jwtIssuer = _configuration["Jwt:Issuer"] ?? "default_issuer";
            var jwtAudience = _configuration["Jwt:Audience"] ?? "default_audience";

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
            new Claim(ClaimTypes.Name, user.Username),
            new Claim("UserId", user.Id.ToString())
        };

            var token = new JwtSecurityToken(
                jwtIssuer,
                jwtAudience,
                claims,
                expires: DateTime.UtcNow.AddHours(2),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}