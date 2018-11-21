using GraphQL.Types;
using DotNetCoreBackend.Services;

namespace DotNetCoreBackend.GraphQLSchema
{
    public class RootQuery : ObjectGraphType
    {
        public RootQuery(IRoomService roomService)
        {
            Name = "RootQuery";

            // FieldAsync<ListGraphType<RoomType>>("rooms", resolve: async _ => await roomService.GetAllRooms());
            Field<RoomQuery>("room", resolve: _ => new {});
            Field<FoodQuery>("food", resolve: _ => new {});
        }
    }
}
