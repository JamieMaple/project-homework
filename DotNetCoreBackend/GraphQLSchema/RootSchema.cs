using GraphQL.Types;
using GraphQL;

namespace DotNetCoreBackend.GraphQLSchema
{
    public class RootSchema : Schema
    {
        public RootSchema(IDependencyResolver resolver): base(resolver)
        {
            Query = resolver.Resolve<RootQuery>();
        }
    }
}
