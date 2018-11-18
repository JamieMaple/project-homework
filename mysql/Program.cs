using System;
using Dapper;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace mysql
{
    [Table("todos")] 
    public class Todo {
        public int id { get; }

        public string content { get; set; }

        public string isFinished { get; set; }
    }

    public class AppDb : IDisposable
    {
        static string connString = "server=localhost;user =root;password=root;database=todo";
        public readonly MySqlConnection connection = new MySqlConnection(connString);
        public void Dispose()
        {
            connection.Close();
        }

        public async Task<List<Todo>> GetAll() {
            var todos = await connection.QueryAsync<Todo>("SELECT * FROM todos");
            return todos.ToList();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            AppDb Db = new AppDb();
            List<Todo> todos = Db.GetAll().Result;
            Console.WriteLine(todos.FirstOrDefault().content);
        }
    }
}
