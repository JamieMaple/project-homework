using GraphQL.Types;
using DotNetCoreBackend.Services;
using DotNetCoreBackend.Security;

using GraphQL.Authorization;

namespace DotNetCoreBackend.GraphQLSchema
{
    public class RootQuery : ObjectGraphType
    {
        public RootQuery(IRoomService roomService)
        {
            Name = "RootQuery";
            Description = "管理员后台查询模块，除 user token 外其他都需要登陆";

            // FieldAsync<ListGraphType<RoomType>>("rooms", resolve: async _ => await roomService.GetAllRooms());
            Field<UserQuery>("user", resolve: _ => new {});
            Field<RoomQuery>("room", resolve: _ => new {}).AuthorizeWith(Policy.WaiterPolicy);
            Field<FoodQuery>("food", resolve: _ => new {}).AuthorizeWith(Policy.WaiterPolicy);
            // Field<OrderQuery>("order", resolve: _ => new {}).AuthorizeWith(Policy.AdminPolicy);
        }
    }
}
