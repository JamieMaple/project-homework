using GraphQL;

namespace empty.Schema
{
    public class TodoSchema : GraphQL.Types.Schema
    {
        public TodoSchema(IDependencyResolver resolver) : base(resolver)
        {
            Query = resolver.Resolve<TodoQuery>();
            Mutation = resolver.Resolve<TodoMutation>();
        }
    }
}
