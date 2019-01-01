using GraphQL;
using GraphQL.Types;

using DotNetCoreBackend.Services;
using DotNetCoreBackend.DAL;

namespace DotNetCoreBackend.GraphQLSchema
{
    public class UserQuery : ObjectGraphType
    {
        public UserQuery(IUserService userService)
        {
            Name = "UserQuery";
            Description = "包含了用户登陆等功能";

            FieldAsync<StringGraphType>(
                "token",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<UserInputType>> { Name = "user" }
                ),
                resolve: async context =>
                {
                    var user = context.GetArgument<LoginUser>("user");

                    if (user.Username == "" || user.Password == "")
                    {
                        throw new ExecutionError("bad username or password input");
                    }

                    var token = await userService.Authentication(user.Username, user.Password);
                    if (token == "")
                    {
                        throw new ExecutionError("username or password error.");
                    }
                    return token;
                });
            FieldAsync<ListGraphType<DotNetCoreBackend.GraphQLSchema.UserType>>(
                "getUserList",
                resolve: async context =>
                {
                    return await userService.GetUserList(0, 100);
                });
        }
    }
}
