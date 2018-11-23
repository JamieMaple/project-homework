using System.Linq;
using System.Security.Claims;
using GraphQL;
using GraphQL.Types;

using DotNetCoreBackend.Services;
using DotNetCoreBackend.DAL;

namespace DotNetCoreBackend.GraphQLSchema
{
    public class RoomMutation : ObjectGraphType
    {
        public RoomMutation(IRoomService roomService)
        {
            Name = "RoomMutation";
            Description = "这里主要包含了修改房间状态功能";
            // some mutation
            FieldAsync<BooleanGraphType>(
                "changeRoomStatus",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "roomId" },
                    new QueryArgument<NonNullGraphType<RoomStatusEnum>> { Name = "status" }
                ),
                resolve: async context =>
                {
                    var roomId = context.GetArgument<int>("roomId");
                    var status = context.GetArgument<RoomStatus>("status");

                    var userId = UserHelpers.GetUserIdFromContext(context.UserContext);

                    return await roomService.ChangeRoomStatus(roomId, userId, status);
                });
        }
    }
}
