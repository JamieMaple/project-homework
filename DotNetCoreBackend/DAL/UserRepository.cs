using Microsoft.Extensions.Configuration;

namespace DotNetCoreBackend.DAL
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        public UserRepository(IConfiguration config) : base(config) {  }

        /*
         *  curd
         */

    }

    public interface IUserRepository
    {

    }
}
