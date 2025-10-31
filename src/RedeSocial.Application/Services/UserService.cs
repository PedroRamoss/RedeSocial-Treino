using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using RedeSocial.Application.Models;
using RedeSocial.Application.Services.Interfaces;
using RedeSocial.Domain.Entities;
using RedeSocial.Domain.Interfaces.Repositories;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace RedeSocial.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;

        public UserService(IUserRepository userRepository, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _configuration = configuration;

        }

        public async Task<Result<object>> LoginAsync(string username, string password)
        {

            var user = await _userRepository.GetByUsernameAsync(username);

            if (user is null || !BCrypt.Net.BCrypt.Verify(password, user.PasswordHash))
            {
                return Result.Failure(Errors.BadRequest);
            }

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = GenerateToken(user, tokenHandler);

            return new { UserId = user.Id, AccessToken = tokenHandler.WriteToken(token), ExpiresIn = token.ValidTo };
        }

        public async Task<Result> CreateUserAsync(User user)
        {
            try
            {
                user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(user.Password);

                await _userRepository.CreateAsync(user);

                return Result.Success();
            }
            catch (Exception ex)
            {
                return Errors.BadRequest;
            }

        }

        public async Task<Result<object>> UpdateUserAsync(Guid id, UserUpdateDto user)
        {
            try
            {
                if (!string.IsNullOrEmpty(user.Password))
                    user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);

                var refreshUser = await _userRepository.GetByIdAsync(id);

                if (refreshUser is null)
                    return Result.Failure(Errors.AccountNotFound);

                var result = await _userRepository.UpdateUserAsync(id, user);

                if (result)
                {
                    var tokenHandler = new JwtSecurityTokenHandler();

                    var token = GenerateToken(refreshUser, tokenHandler);

                    return new { UserId = id, AccessToken = tokenHandler.WriteToken(token), ExpiresIn = token.ValidTo };
                }

                return Result.Failure(Errors.BadRequest);
            }
            catch (Exception ex)
            {
                return Errors.UnprocessableEntity;
            }
        }

        private SecurityToken GenerateToken(User user, JwtSecurityTokenHandler tokenHandler)
        {
            var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]!);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim("UserId", user.Id.ToString()),
                    new Claim("UserName", user.UserName)
                 }),
                Issuer = _configuration["Jwt:Issuer"],
                Audience = _configuration["Jwt:Audience"],
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            return tokenHandler.CreateToken(tokenDescriptor);
        }
    }
}
