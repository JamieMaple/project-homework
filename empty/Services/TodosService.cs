using System.Collections.Generic;
using empty.Models;
using System.Linq;

namespace empty.Services
{
    public class TodosService : ITodosService
    {
        public List<Todo> todos = new List<Todo>();
        public TodosService()
        {
            todos.Add(new Todo("todo - 1"));
            todos.Add(new Todo("todo - 1"));
            todos.Add(new Todo("todo - 1"));
            todos.Add(new Todo("todo - 1"));
            todos.Add(new Todo("todo - 1"));
        }

        public List<Todo> GetTodos()
        {
            return todos;
        }

        public Todo AddTodo(string content)
        {
            Todo newTodo = new Todo(content);
            todos.Add(newTodo);
            return newTodo;
        }

        public bool DeleteTodoById(int id)
        {
            var newTodos = todos.Where(item => item.id != id);
            if (newTodos.Count() == todos.Count())
            {
                return false;
            }
            else
            {
                todos = (List<Todo>)newTodos;
                return true;
            }
        }

        public bool ChangeTodoById(int id, string content, bool isFinished)
        {
            Todo todo = todos.FirstOrDefault(item => item.id == id);
            if (todo == null) {
                return false;
            } else {
                todo.content = content;
                todo.isFinished = isFinished;
                return true;
            }
        }

    }

    public interface ITodosService
    {
        List<Todo> GetTodos();
        Todo AddTodo(string cotent);
        bool ChangeTodoById(int id, string content, bool status);
        bool DeleteTodoById(int id);
    }

}
