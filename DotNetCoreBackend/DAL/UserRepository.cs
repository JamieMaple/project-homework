using Dapper.FastCrud;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace DotNetCoreBackend.DAL
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        public UserRepository(IConfiguration config) : base(config) {  }

        /*
         *  curd
         */

        // create new user
        public async Task<bool> NewUser(string username, string password, UserType usertype)
        {
            // password hask & salt
            var newUser = new LoginUser{
                Username = username,
                Password = password,
                Type = usertype,
                CreateAt = GetTime()
            };
            using (var conn = Connection)
            {
                conn.Open();
                await conn.InsertAsync(newUser);
            }
            return true;
        }

    }


    public interface IUserRepository
    {
        Task<bool> NewUser(string username, string password, UserType UserType);
    }
}
