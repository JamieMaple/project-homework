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
            Description = "这里主要包含了修改房间状态等功能";

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

            FieldAsync<BooleanGraphType>(
                "deleteRoom",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "roomId" }
                ),
                resolve: async context =>
                {
                    var roomId = context.GetArgument<int>("roomId");
                    return await roomService.DeleteRoomById(roomId);
                }
            );

            FieldAsync<BooleanGraphType>(
                    "createRoom",
                    arguments: new QueryArguments(
                        new QueryArgument<NonNullGraphType<RoomInputType>> { Name = "room" }
                        ),
                resolve: async context =>
                {
                    var room = context.GetArgument<Room>("room");
                    return await roomService.AddRoom(room);
                }
            );

            FieldAsync<BooleanGraphType>(
                "updateRoom",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<RoomInputType>> { Name = "room" }
                    ),
                resolve: async context =>
                {
                    var room = context.GetArgument<Room>("room");

                    return await roomService.UpdateRoomInfo(room);
                }
            );
        }
    }
}
