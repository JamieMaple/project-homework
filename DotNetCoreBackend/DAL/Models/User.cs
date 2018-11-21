using System.ComponentModel.DataAnnotations.Schema;

namespace DotNetCoreBackend.DAL
{
    public enum UserType
    {
        Normal = 1,
        Waiter = 2,
        Admin  = 4,
        Root   = 8
    }


    [Table("user")]
    public class User : Base
    {
        public string Username { get; set; }

        // input password not in db

        public UserType Type { get; set; }

        [Column("last_login_at")]
        public long LastLoginAt { get; set; }
    }


    [Table("user")]
    public class LoginUser : User
    {
        public string Password { get; set; }

        public string Salt { get; set; }
    }
}
