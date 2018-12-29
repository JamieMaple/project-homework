using GraphQL;
using GraphQL.Types;

using DotNetCoreBackend.DAL;
using DotNetCoreBackend.Services;

namespace DotNetCoreBackend.GraphQLSchema
{
    public class UserMutation : ObjectGraphType
    {
        public UserMutation(IUserService userService)
        {
            Name = "UserMutation";
            Description = "主要包含了用户注册等功能";

            FieldAsync<BooleanGraphType>(
                "newWaiter",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<UserInputType>> { Name = "user" }
                ),
                resolve: async context =>
                {
                    var user = context.GetArgument<LoginUser>("user");

                    if (user == null || user.Username == null || user.Password == null)
                    {
                        throw new ExecutionError("bad username or password input");
                    }

                    string username = user.Username.Trim();
                    string password = user.Password.Trim();

                    if (username == "" || password == "")
                    {
                        throw new ExecutionError("bad username or password input");
                    }

                    return await userService.NewWaiter(user.Username, user.Password);
                });
        }
    }
}
