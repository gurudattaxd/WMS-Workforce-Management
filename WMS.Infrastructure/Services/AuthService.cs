using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using WMS.Application.DTOs;
using WMS.Application.Interfaces;
using WMS.Domain.Entities;
using WMS.Infrastructure.Data;

namespace WMS.Infrastructure.Services
{
    public class AuthService : IAuthService
    {
        private readonly WMSDbContext _context;
        private readonly IConfiguration _config;

        public AuthService(WMSDbContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }

        public async Task<LoginResponseDto?> LoginAsync(LoginDto dto)
        {
            var user = await _context.UserLogins
                .Include(u => u.Role)
                .FirstOrDefaultAsync(u => u.Username == dto.Username);

            if (user == null) return null;

            // Verify password
            if (!VerifyPassword(dto.Password, user.PasswordHash)) return null;

            // Update last login
            user.LastLogin = DateTime.Now;
            await _context.SaveChangesAsync();

            // Generate JWT token
            var token = GenerateToken(user);
            var expiry = DateTime.Now.AddMinutes(
                double.Parse(_config["Jwt:ExpiryMinutes"] ?? "60"));

            return new LoginResponseDto
            {
                Token = token,
                Username = user.Username,
                Role = user.Role?.RoleName ?? "",
                UserId = user.UserId,
                Expiry = expiry
            };
        }

        public async Task<bool> RegisterAsync(RegisterDto dto)
        {
            // Check if username exists
            var exists = await _context.UserLogins
                .AnyAsync(u => u.Username == dto.Username);
            if (exists) return false;

            var user = new UserLogin
            {
                Username = dto.Username,
                PasswordHash = HashPassword(dto.Password),
                RoleId = dto.RoleId
            };

            _context.UserLogins.Add(user);
            await _context.SaveChangesAsync();
            return true;
        }

        private string GenerateToken(UserLogin user)
        {
            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_config["Jwt:Key"]!));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Role, user.Role?.RoleName ?? "Employee")
            };

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(
                    double.Parse(_config["Jwt:ExpiryMinutes"] ?? "60")),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private string HashPassword(string password)
        {
            using var sha256 = SHA256.Create();
            var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(bytes);
        }

        private bool VerifyPassword(string password, string hash)
        {
            return HashPassword(password) == hash;
        }
    }
}