using GraphQL;

namespace graphql_test.Schema
{
    public class UserSchema : GraphQL.Types.Schema
    {
        public UserSchema(IDependencyResolver resolver): base(resolver) {
            Query = resolver.Resolve<UserQuery>();
        }
    }
}
