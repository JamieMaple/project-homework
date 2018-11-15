using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using empty.Models;
using empty.Services;

namespace empty.Controllers
{
    [Route("api/todos")]
    public class TodosControllers : Controller
    {
        private readonly ITodosService todosStore;

        public TodosControllers (ITodosService todoService)
        {
            todosStore = todoService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Todo>> getTodos()
        {
            Response.StatusCode = StatusCodes.Status200OK;
            return todosStore.GetTodos();
        }

        [HttpPost]
        public Todo addTodo([FromBody] Todo newTodo)
        {
            Response.StatusCode = StatusCodes.Status201Created;
            todosStore.AddTodo(newTodo.content);
            return newTodo;
        }

        [HttpDelete("{id}")]
        public string deleteTodo(int id)
        {
            bool isDelete = todosStore.DeleteTodoById(id);
            if (isDelete) {
                Response.StatusCode = StatusCodes.Status201Created;
                return "deleted";
            } else {
                Response.StatusCode = StatusCodes.Status404NotFound;
                return "";
            }
        }
        
        [HttpPut("{id}")]
        public string updateTodo(int id, [FromBody] Todo updatedTodo)
        {
            Response.StatusCode = StatusCodes.Status201Created;
            bool isUpdated = todosStore.ChangeTodoById(id, updatedTodo.content, updatedTodo.isFinished);
            if (isUpdated) {
                Response.StatusCode = StatusCodes.Status201Created;
                return "updated";
            } else {
                Response.StatusCode = StatusCodes.Status404NotFound;
                return "";
            }
        }

    }
}
