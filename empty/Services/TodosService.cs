using System.Collections.Generic;
using empty.Models;
using empty.DAL;
using System.Threading.Tasks;

namespace empty.Services
{
    public class TodosService : ITodosService
    {
        public List<Todo> todos = new List<Todo>();
        private ITodoRepository _todoRepository;
        public TodosService(ITodoRepository todoRepository)
        {
            _todoRepository = todoRepository;
        }

        public async Task<List<Todo>> GetTodos()
        {
            return await _todoRepository.GetTodosAsync();
        }

        public async Task<bool> AddTodo(string content)
        {
            return await _todoRepository.AddTodo(content);
        }

        public async Task<bool> DeleteTodoById(int id)
        {
            return await _todoRepository.DeleteTodoById(id);
        }

        public async Task<bool> ChangeTodoById(int id, string content, bool isFinished)
        {
            return await _todoRepository.UpdateTodoById(id, content, isFinished);
        }

        public async Task<List<Todo>> GetByIds(List<int> ids)
        {
            return await _todoRepository.GetTodosByIds(ids);
        }

    }

    public interface ITodosService
    {
        Task<List<Todo>> GetTodos();
        Task<bool> AddTodo(string cotent);
        Task<bool> ChangeTodoById(int id, string content, bool status);
        Task<bool> DeleteTodoById(int id);
        Task<List<Todo>> GetByIds(List<int> ids);
    }

}
