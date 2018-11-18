using Microsoft.Extensions.Configuration;
using System.Data;
using MySql.Data.MySqlClient;

namespace empty.DAL
{
    public class BaseRepository {
        private readonly IConfiguration _config;

        public BaseRepository(IConfiguration config)
        {
            _config = config;
        }

        public IDbConnection Connection {
            get {
                return new MySqlConnection(_config.GetConnectionString("MyConnectionString"));
            }
        }
    }
}
