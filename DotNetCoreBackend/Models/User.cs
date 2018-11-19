namespace DotNetCoreBackend.Models
{
    public enum UserType
    {
        Normal = 1,
        Waiter = 2,
        Root   = 4
    }


    public class User : Base
    {
        public string Username { get; set; }

        // input password not in db

        public UserType Type { get; set; }
    }
}
