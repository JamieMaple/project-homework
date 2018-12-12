using System;
using System.Linq;
using Dapper.FastCrud;
using System.Threading.Tasks;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.Extensions.Configuration;

namespace DotNetCoreBackend.DAL
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        public UserRepository(IConfiguration config) : base(config) { }

        /*
         *  curd
         */
        public async Task<bool> NewUser(string username, string password, UserType usertype)
        {
            Tuple<string, string> pair = HashUserPassword(password);
            // password hask & salt
            var newUser = new LoginUser
            {
                Username = username,
                Password = pair.Item1,
                Salt = pair.Item2,
                Type = usertype,
                CreateAt = GetTime()
            };
            using (var conn = Connection)
            {
                conn.Open();
                var result = await conn.FindAsync<LoginUser>(s => s.Where($"{nameof(LoginUser.Username):C}=@Username").WithParameters(new { Username = username }));
                if (result.FirstOrDefault() != null)
                {
                    return false;
                }
                await conn.InsertAsync(newUser);
            }
            return true;
        }

        private Tuple<string, string> HashUserPassword(string password)
        {
            byte[] salt = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }
            string saltString = Convert.ToBase64String(salt);

            return Tuple.Create(HashUserPasswordWithSalt(password, salt), saltString);
        }

        private string HashUserPasswordWithSalt(string password, byte[] salt)
        {
            string hashedPassword = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 10000,
                numBytesRequested: 256 / 8
            ));

            return hashedPassword;
        }

        public string HashUserPasswordWithSalt(string password, string saltString)
        {
            var salt = Convert.FromBase64String(saltString);
            return HashUserPasswordWithSalt(password, salt);
        }

        public async Task<LoginUser> GetUserByUserName(string username)
        {
            using (var conn = Connection)
            {
                conn.Open();
                var result = await conn.FindAsync<LoginUser>(s => s.Where($"{nameof(LoginUser.Username):C}=@Username").WithParameters(new { Username = username }));
                return result.FirstOrDefault();
            }
        }
    }


    public interface IUserRepository
    {
        Task<bool> NewUser(string username, string password, UserType UserType);
        string HashUserPasswordWithSalt(string password, string salt);
        Task<LoginUser> GetUserByUserName(string username);
    }
}
