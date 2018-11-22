using Dapper;
using Dapper.FastCrud;
using System;
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

        public async Task<List<Todo>> GetTodosByIds(List<int> ids)
        {
            var subList = new List<string>();
            subList.Append("id = 1");
            using (var conn = Connection)
            {
                conn.Open();
                ids.ForEach(id => subList.Add($"id = {id}"));
                var wheres = String.Join(" or ", subList.ToArray());
                var sql = $"select * from todos where {wheres}";
                var result = await conn.QueryAsync<Todo>(sql);
                return result.ToList();
            }
        }

        public async Task<bool> AddTodo(string content)
        {
            using (var conn = base.Connection)
            {
                conn.Open();
                try
                {
                    await conn.InsertAsync(new Todo { Content = content });
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
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
        Task<List<Todo>> GetTodosByIds(List<int> ids);
        Task<bool> AddTodo(string content);
        Task<bool> DeleteTodoById(int id);
        Task<bool> UpdateTodoById(int id, string content, bool isFinished);
    }
}
