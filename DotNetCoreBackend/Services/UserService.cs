using System;
using System.Text;
using System.Security.Claims;
using System.Threading.Tasks;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;

using DotNetCoreBackend.DAL;

namespace DotNetCoreBackend.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        private readonly IConfiguration _config;

        public UserService(
            IUserRepository userRepository,
            IConfiguration config
        )
        {
            _userRepository = userRepository;
            _config = config;
        }

        private string TokenBuild()
        {
            var claims = new[] {
                new Claim(ClaimTypes.Role, "waiter")
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Issuer"],
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<string> Authentication(string username, string password)
        {
            await Task.Delay(300);
            return TokenBuild();
        }

        public Task<bool> NewWaiter(string username, string password)
        {
            return _userRepository.NewUser(username, password, UserType.Waiter);
        }

        public async Task<bool> NewAdmin(string username, string password)
        {
            return false;
        }
    }


    public interface IUserService
    {
        Task<string> Authentication(string name, string password);

        Task<bool> NewWaiter(string username, string password);
    }
}
