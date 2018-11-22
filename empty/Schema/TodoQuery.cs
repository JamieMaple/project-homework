using System.Collections.Generic;
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
            FieldAsync<ListGraphType<TodoType>>(
                "todoByIds",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<ListGraphType<IntGraphType>>> { Name = "ids" }
                ),
                resolve: async ctx => {
                    var ids = ctx.GetArgument<List<int>>("ids");
                    return await todoService.GetByIds(ids);
                }
            );
        }
    }
}
