using GraphQL.Types;
using empty.Services;

namespace empty.Schema
{
    public class TodoQuery : ObjectGraphType
    {
        public TodoQuery(ITodosService todoService)
        {
            FieldAsync<ListGraphType<TodoType>>(
                "todos",
                resolve: async _ => await todoService.GetTodos()
            );
        }
    }
}
