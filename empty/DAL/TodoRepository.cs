using Dapper;
using Dapper.FastCrud;
using Microsoft.Extensions.Configuration;
using System.Linq;
using System.Collections.Generic;
using empty.Models;
using System.Threading.Tasks;

namespace empty.DAL
{
    public class TodoRepository : BaseRepository, ITodoRepository
    {
        public TodoRepository(IConfiguration config): base(config) {  }

        public async Task<List<Todo>> GetTodosAsync()
        {
            using (var conn = base.Connection)
            {
                conn.Open();
                var result = await conn.FindAsync<Todo>();
                return result.ToList();
            }
        }

        public async Task AddTodo(string content)
        {
            using (var conn = base.Connection)
            {
                conn.Open();
                await conn.InsertAsync(new Todo { Content = content });
            }
        }

        public async Task<bool> DeleteTodoById(int id)
        {
            using (var conn = base.Connection)
            {
                conn.Open();
                return await conn.DeleteAsync(new Todo { Id = id });
            }
        }

        public async Task<bool> UpdateTodoById(int id, string content, bool isFinished)
        {
            using (var conn = base.Connection)
            {
                conn.Open();
                return await conn.UpdateAsync(new Todo { Id = id, Content = content, IsFinished = isFinished });
            }
        }
    }


    public interface ITodoRepository {
        Task<List<Todo>> GetTodosAsync();
        Task AddTodo(string content);
        Task<bool> DeleteTodoById(int id);
        Task<bool> UpdateTodoById(int id, string content, bool isFinished);
    }
}
