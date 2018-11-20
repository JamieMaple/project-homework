using MySql.Data.MySqlClient;
using System;
using System.Data;
using Microsoft.Extensions.Configuration;

namespace DotNetCoreBackend.DAL
{
    public class BaseRepository
    {
        private readonly IConfiguration Configuration;

        public BaseRepository(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IDbConnection Connection {
            get {
                return new MySqlConnection(Configuration.GetConnectionString("MySqlConnection"));
            }
        }

        public long GetTime()
        {
            return new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds();
        }
    }
}
