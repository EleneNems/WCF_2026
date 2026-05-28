using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Wordle_Application.DTOs;
using Wordle_Application.Interfaces;
using Wordle_Domain.Entities;

namespace Wordle_Infrastructure.Services
{
    public class AuthService : IAuthService
    {
        private readonly AppDBContext _context;

        public AuthService(AppDBContext context)
        {
            _context = context;
        }

        public async Task<AuthResponseDto> RegisterAsync(RegisterDto dto)
        {
            string email = dto.Username.Trim().ToLower();

            if (!IsValidEmail(email))
                throw new Exception("Please enter a valid email address.");

            bool exists = await _context.Users
                .AnyAsync(u => u.Username.ToLower() == email);

            if (exists)
                throw new Exception("This email is already registered.");

            if (string.IsNullOrWhiteSpace(dto.Password))
                throw new Exception("Password is required.");

            User user = new User
            {
                Username = email,
                Password = dto.Password
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return new AuthResponseDto
            {
                UserId = user.Id,
                Username = user.Username,
                Message = "Registration successful."
            };
        }

        public async Task<AuthResponseDto> LoginAsync(LoginDto dto)
        {
            string email = dto.Username.Trim().ToLower();

            if (!IsValidEmail(email))
                throw new Exception("Please enter a valid email address.");

            User? user = await _context.Users
                .FirstOrDefaultAsync(u => u.Username.ToLower() == email);

            if (user == null)
                throw new Exception("User not found.");

            return new AuthResponseDto
            {
                UserId = user.Id,
                Username = user.Username,
                Message = "Login successful."
            };
        }

        private bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";

            return Regex.IsMatch(email, pattern);
        }
    }
}
