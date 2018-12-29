using GraphQL.Types;

using DotNetCoreBackend.DAL;

namespace DotNetCoreBackend.GraphQLSchema
{
    public class RoomInputType : InputObjectGraphType<Room>
    {
        public RoomInputType()
        {
            Field(x => x.Floor);
            Field(x => x.Name);
        }
    }
}
