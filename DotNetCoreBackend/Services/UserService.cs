using DotNetCoreBackend.DAL;

namespace DotNetCoreBackend.Services
{
    public class UserService : IUserService
    {
        public UserService(IUserRepository userRepository)
        {

        }
    }


    public interface IUserService
    {

    }
}
