using GraphQL.Types;
using GraphQL.Authorization;

using DotNetCoreBackend.Security;

namespace DotNetCoreBackend.GraphQLSchema
{
    public class RootMutation : ObjectGraphType
    {
        public RootMutation()
        {
            Name = "adminMutation";
            Description = "管理员修改模块, 包含副作用，均需要 user token （特权级别：admin）";
            this.AuthorizeWith(Policy.AdminPolicy);

            Field<UserMutation>("user", resolve: _ => new { });

            Field<RoomMutation>("room", resolve: _ => new { });

            Field<FoodMutation>("food", resolve: _ => new { });

            Field<OrderMutation>("order", resolve: _ => new { });
        }
    }
}
