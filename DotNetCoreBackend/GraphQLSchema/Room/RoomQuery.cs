using GraphQL.Types;
using System.Collections.Generic;

using DotNetCoreBackend.Services;
using DotNetCoreBackend.DAL;

namespace DotNetCoreBackend.GraphQLSchema
{
    public class RoomQuery : ObjectGraphType
    {
        public RoomQuery(IRoomService roomService)
        {
            Name = "RoomQuery";
            Description = "房间模块，主要包含房间的查询";

            FieldAsync<ListGraphType<RoomType>>(
                "rooms",
                resolve: async _ => await roomService.GetAllRooms()
            );
        }
    }
}
