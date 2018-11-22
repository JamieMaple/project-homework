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
                    new QueryArgument<IntGraphType> { Name = "roomId" },
                    new QueryArgument<RoomStatusEnum> { Name = "status" }
                ),
                resolve: async context =>
                {
                    var roomId = context.GetArgument<int>("roomId");
                    var status = context.GetArgument<RoomStatus>("status");

                    if (status <= 0) throw new ExecutionError("status error");

                    return await roomService.ChangeRoomStatus(roomId, status);
                });
        }
    }
}
