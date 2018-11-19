using GraphQL.Types;
using empty.Models;

namespace empty.Schema
{
    public class TodoType : ObjectGraphType<Todo>
    {
        public TodoType()
        {
            Name = "todo";
            Field(x => x.Id);
            Field(x => x.Content);
            Field(x => x.IsFinished);
        }
    }
}
