using System;
using System.Linq;
using Dapper.FastCrud;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.Extensions.Configuration;

namespace DotNetCoreBackend.DAL
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        public UserRepository(IConfiguration config) : base(config) { }

        public async Task<bool> NewUser(string username, string password, UserType usertype)
        {
            Tuple<string, string> pair = HashUserPassword(password);

            var newUser = new LoginUser
            {
                Username = username,
                Password = pair.Item1,
                Salt = pair.Item2,
                Type = usertype > UserType.Admin ? UserType.Waiter : usertype,
                CreateAt = GetTime()
            };

            using (var conn = Connection)
            {
                var result = await conn.FindAsync<LoginUser>(s => s.Where($"{nameof(LoginUser.Username):C}=@Username").WithParameters(new { Username = username }));
                if (result.FirstOrDefault() != null)
                {
                    Error("用户已存在");
                    return false;
                }
                else
                {
                    await conn.InsertAsync(newUser);
                    return true;
                }
            }
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
                var result = await conn.FindAsync<LoginUser>(s => s.Where($"{nameof(LoginUser.Username):C}=@Username").WithParameters(new { Username = username }));
                return result.FirstOrDefault();
            }
        }

        public async Task<bool> DeleteUser(int operateId, int deleteId)
        {
            using (var conn = Connection)
            {
                var operatingUser = await conn.GetAsync(new User { Id = operateId });
                var deleteUser = await conn.GetAsync(new User { Id = deleteId });

                if (isNotExist(operatingUser) || isNotExist(deleteUser))
                {
                    Error("要删除的用户或进行删除操作的用户不存在");
                    return false;
                }

                if (operatingUser.Type > deleteUser.Type)
                {
                    return await Delete(deleteId, "user");
                }
                else
                {
                    Error("Permission denied");
                    return false;
                }
            }
        }

        public async Task<bool> ChangeUserPassword(string username, string password)
        {
            var user = await GetUserByUserName(username);

            if (isNotExist(user))
            {
                Error("用户不存在");
                return false;
            }

            using (var conn = Connection)
            {
                var tuple = HashUserPassword(password);
                user.Password = tuple.Item1;
                user.Salt = tuple.Item2;
                return await conn.UpdateAsync(user);
            }
        }
        
        public async Task<List<User>> GetUserList(int offset, int limit)
        {
            var users = await GetList<User>(offset, limit);
            return users.ToList();
        }
    }


    public interface IUserRepository
    {
        Task<bool> NewUser(string username, string password, UserType UserType);
        string HashUserPasswordWithSalt(string password, string salt);
        Task<LoginUser> GetUserByUserName(string username);
        Task<bool> DeleteUser(int operateId, int deleteId);
        Task<bool> ChangeUserPassword(string username, string password);
        Task<List<User>> GetUserList(int offset, int limit);
    }
}
