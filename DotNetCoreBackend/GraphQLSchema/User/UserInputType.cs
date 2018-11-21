using GraphQL.Types;

using DotNetCoreBackend.DAL;

namespace DotNetCoreBackend.GraphQLSchema
{
    public class UserInputType : InputObjectGraphType<LoginUser>
    {
        public UserInputType()
        {
            Name = "UserInput";
            Field(x => x.Username);
            Field(x => x.Password);
        }
    }
}
