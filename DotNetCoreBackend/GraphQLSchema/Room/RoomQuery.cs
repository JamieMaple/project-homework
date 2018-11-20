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
            Name = "Room";

            FieldAsync<ListGraphType<RoomType>>(
                "rooms",
                resolve: async _ => await roomService.GetAllRooms()
            );
        }
    }
}
