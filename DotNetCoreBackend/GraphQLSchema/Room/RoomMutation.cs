using GraphQL.Types;

using DotNetCoreBackend.Services;

namespace DotNetCoreBackend.GraphQLSchema
{
    public class RoomMutation : ObjectGraphType
    {
        public RoomMutation(IRoomService roomService)
        {
            // some mutation
        }
    }
}
