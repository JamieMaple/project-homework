using GraphQL;
using GraphQL.Types;
using GraphQL.Authorization;

using DotNetCoreBackend.Services;
using DotNetCoreBackend.Security;

namespace DotNetCoreBackend.GraphQLSchema
{
    public class BasicQuery : ObjectGraphType
    {
        public BasicQuery(
            IRoomService roomService,
            IFoodService foodService,
            IUserService userService
        )
        {
            Name = "query";
            Description = "查询模块";

            Field<RoomQuery>("room", resolve: _ => new {});

            Field<FoodQuery>("food", resolve: _ => new {});

            Field<UserQuery>("user", resolve: _ => new {});

        }
    }

    public class BasicMutation : ObjectGraphType
    {
        public BasicMutation(IUserService userService)
        {
            Name = "mutataion";
            Description = "修改模块";

            Field<OrderMutation>("order", resolve: _ => new {}).AuthorizeWith(Policy.WaiterPolicy);
            Field<RoomMutation>("room", resolve: _ => new {}).AuthorizeWith(Policy.WaiterPolicy);
            Field<UserMutation>("user", resolve: _ => new {}).AuthorizeWith(Policy.AdminPolicy);
        }
    }


    public class BasicSchema : Schema
    {
        public BasicSchema(IDependencyResolver resolver): base(resolver)
        {
            Query = resolver.Resolve<BasicQuery>();

            Mutation = resolver.Resolve<BasicMutation>();
        }
    }
}
