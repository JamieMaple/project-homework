using GraphQL.Types;
using graphql_test.Models;

namespace graphql_test.Schema
{
    public class UserType : ObjectGraphType<User>
    {
        public UserType()
        {
            Name = "User";
            Field(x => x.Id);
            Field(x => x.Nickname);
            Field(x => x.Email);
        }
    }
}
