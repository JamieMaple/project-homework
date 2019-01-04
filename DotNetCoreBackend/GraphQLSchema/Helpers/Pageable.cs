using GraphQL;
using GraphQL.Types;

namespace DotNetCoreBackend.GraphQLSchema
{
    public class Pageable
    {
        public int Limit;

        public int Offset;

        public Pageable() { }

        public Pageable(object context, int max = 30)
        {
            var pageableContext = context as ResolveFieldContext<object>;
            if (pageableContext == null)
            {
                throw new ExecutionError("bad context provide!");
            }

            Offset = pageableContext.GetArgument<int>("offset");
            Limit = pageableContext.GetArgument<int>("limit");

            if (Offset <= 0)
            {
                Offset = 0;
            }

            if (Limit <= 0 || Limit > max)
            {
                Limit = max;
            }
        }

        public static Pageable defaultPageable()
        {
            return new Pageable { Limit = 150, Offset = 0 };
        }
    }
}
