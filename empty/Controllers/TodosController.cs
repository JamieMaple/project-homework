using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using empty.Models;
using empty.Services;

namespace empty.Controllers
{
    [Route("api/todos")]
    public class TodosControllers : Controller
    {
        private readonly ITodosService _todosStore;

        public TodosControllers (ITodosService todoService)
        {
            _todosStore = todoService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Todo>>> getTodos()
        {
            Response.StatusCode = StatusCodes.Status200OK;
            return await _todosStore.GetTodos();
        }

        [HttpPost]
        public async Task<bool> addTodo([FromBody] Todo newTodo)
        {
            Response.StatusCode = StatusCodes.Status201Created;
            await _todosStore.AddTodo(newTodo.Content);
            return true;
        }

        [HttpDelete("{id}")]
        public async Task<bool> deleteTodo(int id)
        {
            return await _todosStore.DeleteTodoById(id);
        }
        
        [HttpPut("{id}")]
        public async Task<bool> updateTodo(int id, [FromBody] Todo updatedTodo)
        {
            Response.StatusCode = StatusCodes.Status201Created;
            await _todosStore.ChangeTodoById(id, updatedTodo.Content, updatedTodo.IsFinished);
            return true;
        }

    }
}
