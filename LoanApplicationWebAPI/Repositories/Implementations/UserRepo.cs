using LoanApplicationWebAPI.Data;
using LoanApplicationWebAPI.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using LoanApplicationWebAPI.Repositories.Interfaces;

namespace LoanApplicationWebAPI.Repository
{
    public class UserRepo : IUserRepo
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _config;

        public UserRepo(AppDbContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }

        // ---------------- CRUD ----------------

        public async Task<IEnumerable<User>> GetAll()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetById(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<User> Add(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<User> Update(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task Delete(int id)
        {
            var user = await GetById(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
        }

        // ---------------- Login ----------------
        public async Task<LoginResponseViewModel> LoginAsync(LoginViewModel login)
        {
            // Find user by email
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == login.Email);

            if (user == null)
                return new LoginResponseViewModel
                {
                    IsSuccess = false,
                    Message = "User not found"
                };

            // Check password (use hashing in production)
            if (user.PasswordHash != login.Password)
                return new LoginResponseViewModel
                {
                    IsSuccess = false,
                    Message = "Invalid password"
                };

            // ---------------- JWT Token Generation ----------------
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserId.ToString()),
                new Claim(ClaimTypes.Name, user.FirstName + " " + user.LastName),
                new Claim(ClaimTypes.Role, user.UserRoleType.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JwtSettings:SecretKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _config["JwtSettings:Issuer"],
                audience: _config["JwtSettings:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(Convert.ToDouble(_config["JwtSettings:ExpiryMinutes"])),
                signingCredentials: creds
            );

            string tokenString = new JwtSecurityTokenHandler().WriteToken(token);

            // ---------------- Return Login Response ----------------
            return new LoginResponseViewModel
            {
                UserId = user.UserId,
                FullName = user.FirstName + " " + user.LastName,
                Role = user.UserRoleType.ToString(),
                Token = tokenString,
                IsSuccess = true,
                Message = "Login successful"
            };
        }
    }
}
