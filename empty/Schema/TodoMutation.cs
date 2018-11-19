using GraphQL.Types;
using empty.Models;
using empty.Services;

namespace empty.Schema
{
    public class TodoMutation : ObjectGraphType
    {
        public TodoMutation(ITodosService todoService)
        {
            Name = "todoMutation";

            // add todo
            FieldAsync<BooleanGraphType>(
                "createTodo",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<TodoInput>> { Name = "todo" }
                ),
                resolve: async context =>
                {
                    var todo = context.GetArgument<Todo>("todo");
                    if (todo == null)
                    {
                        return false;
                    }
                    return await todoService.AddTodo(todo.Content);
                }
            );

            // update todo
            FieldAsync<BooleanGraphType>(
                "updateTodo",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "id" },
                    new QueryArgument<NonNullGraphType<TodoInput>> { Name = "todo" }
                    ),
                resolve: async context =>
                {
                    var id = context.GetArgument<int>("id");
                    var todo = context.GetArgument<Todo>("todo");

                    if (todo == null)
                    {
                        return false;
                    }

                    todo.Id = id;

                    return await todoService.ChangeTodoById(todo.Id, todo.Content, todo.IsFinished);
                }
            );

            // delete todo
            FieldAsync<BooleanGraphType>(
                "deleteTodo",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "id" }
                ),
                resolve: async context =>
                {
                    var id = context.GetArgument<int>("id");
                    return await todoService.DeleteTodoById(id);
                }
            );
        }
    }
}
