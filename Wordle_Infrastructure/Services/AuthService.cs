using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using Wordle_Application.DTOs;
using Wordle_Application.Interfaces;
using Wordle_Domain.Entities;

namespace Wordle_Infrastructure.Services
{
    public class AuthService : IAuthService
    {
        private readonly AppDBContext _context;
        private readonly IConfiguration _config;

        public AuthService(AppDBContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }

        public async Task<AuthResponseDto> RegisterAsync(RegisterDto dto)
        {
            string email = dto.Email.Trim().ToLower();

            if (!IsValidEmail(email))
                throw new Exception("Please enter a valid email address.");

            bool exists = await _context.Users
                .AnyAsync(u => u.Email.ToLower() == email);

            if (exists)
                throw new Exception("This email is already registered.");

            if (string.IsNullOrWhiteSpace(dto.Password))
                throw new Exception("Password is required.");

            var user = new User
            {
                Email = email,
                PasswordHash = HashPassword(dto.Password)
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            var statistic = new Statistic
            {
                UserId = user.Id,
                GamesPlayed = 0,
                Wins = 0,
                CurrentStreak = 0,
                MaxStreak = 0,
                TotalPoints = 0
            };

            _context.Statistics.Add(statistic);
            await _context.SaveChangesAsync();

            return new AuthResponseDto
            {
                UserId = user.Id,
                Email = user.Email,
                Token = GenerateToken(user),
                Message = "Registration successful."
            };
        }

        public async Task<AuthResponseDto> LoginAsync(LoginDto dto)
        {
            string email = dto.Email.Trim().ToLower();

            if (!IsValidEmail(email))
                throw new Exception("Please enter a valid email address.");

            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Email.ToLower() == email);

            if (user == null)
                throw new Exception("User not found.");

            if (!VerifyPassword(dto.Password, user.PasswordHash))
                throw new Exception("Incorrect password.");

            return new AuthResponseDto
            {
                UserId = user.Id,
                Email = user.Email,
                Token = GenerateToken(user),
                Message = "Login successful."
            };
        }

        private string HashPassword(string password)
        {
            using var sha256 = SHA256.Create();
            var bytes = sha256.ComputeHash(
                Encoding.UTF8.GetBytes(password));

            return Convert.ToBase64String(bytes);
        }

        private bool VerifyPassword(string password, string hash)
        {
            return HashPassword(password) == hash;
        }

        private string GenerateToken(User user)
        {
            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_config["Jwt:Key"]!));

            var creds = new SigningCredentials(
                key,
                SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(
                    ClaimTypes.NameIdentifier,
                    user.Id.ToString()),

                new Claim(
                    ClaimTypes.Email,
                    user.Email)
            };

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddDays(7),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler()
                .WriteToken(token);
        }

        private bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            return Regex.IsMatch(
                email,
                @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        }
    }
}