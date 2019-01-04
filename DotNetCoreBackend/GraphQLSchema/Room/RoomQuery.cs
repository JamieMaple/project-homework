using GraphQL.Types;

using DotNetCoreBackend.Services;

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
                arguments: new QueryArguments(
                    new QueryArgument<IntGraphType> { Name = "limit" },
                    new QueryArgument<IntGraphType> { Name = "offset" }
                ),
                resolve: async context =>
                {
                    var page = new Pageable(context, 120);
                    return await roomService.GetAllRooms(page.Offset, page.Limit);
                }
            );
        }
    }
}
