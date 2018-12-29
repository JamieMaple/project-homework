using GraphQL.Types;

using DotNetCoreBackend.DAL;

namespace DotNetCoreBackend.GraphQLSchema
{
    public class RoomStatusEnum : EnumerationGraphType<RoomStatus> {  }


    public class RoomType : ObjectGraphType<Room>
    {
        public RoomType()
        {
            Name = "room";
            Description = "房间信息";

            Field(x => x.Id);
            Field(x => x.Name);
            Field<RoomStatusEnum>("status");
            Field(x => x.Floor);
        }
    }
}
