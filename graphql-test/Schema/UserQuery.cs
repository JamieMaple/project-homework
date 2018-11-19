using System.Collections.Generic;
using GraphQL.Types;
using graphql_test.Models;

namespace graphql_test.Schema
{
    public class UserQuery : ObjectGraphType
    {
        public UserQuery()
        {
            Field<ListGraphType<UserType>>( 
                "user",
                resolve: ctx => new List<User>() {
                    new User { Id = 1, Nickname = "hello", Email = "jamiemaple007@gmail.com" }
                }
            );
        }
    }
}
