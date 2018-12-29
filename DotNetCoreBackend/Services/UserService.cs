using System;
using System.Text;
using System.Security.Claims;
using System.Threading.Tasks;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;

using DotNetCoreBackend.DAL;
using DotNetCoreBackend.Security;

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

        private string GetRole(UserType type)
        {
            switch (type)
            {
                case UserType.Root:
                    return Role.RootRole;
                case UserType.Admin:
                    return Role.AdminRole;
                case UserType.Waiter:
                    return Role.WaiterRole;
                default:
                    return Role.Normal;
            }
        }

        private string TokenBuild(int userId, UserType type)
        {
            var claims = new[] {
                new Claim(ClaimTypes.Role, GetRole(type)),
                new Claim(ClaimTypes.PrimarySid, Convert.ToString(userId)),
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
            var user = await _userRepository.GetUserByUserName(username);

            if (user == null)
            {
                return "";
            }

            var hashedPassword = _userRepository.HashUserPasswordWithSalt(password, user.Salt);

            return hashedPassword.Equals(user.Password) ? TokenBuild(user.Id, user.Type) : "";
        }

        public Task<bool> NewWaiter(string username, string password)
        {
            return _userRepository.NewUser(username, password, UserType.Waiter);
        }

        public Task<bool> NewAdmin(string username, string password)
        {
            return _userRepository.NewUser(username, password, UserType.Admin);
        }
    }


    public interface IUserService
    {
        Task<string> Authentication(string name, string password);

        Task<bool> NewWaiter(string username, string password);
    }
}
