using GraphQL.Types;
using empty.Models;

namespace empty.Schema
{
    public class TodoInput : InputObjectGraphType<Todo>
    {
        public TodoInput()
        {
            Name = "TodoInput";
            Description = "";
            Field(x => x.Content);
            Field(x => x.IsFinished, nullable: true);
        }
    }
}
