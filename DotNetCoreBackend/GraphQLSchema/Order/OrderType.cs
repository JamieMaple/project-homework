using GraphQL.Types;

using DotNetCoreBackend.DAL;

namespace DotNetCoreBackend.GraphQLSchema
{
    public class OrderType : ObjectGraphType<Order>
    {
        public OrderType()
        {
            Field(x => x.Id);
            Field(x => x.RoomId);
            Field(x => x.WaiterId);
            Field<ListGraphType<FoodListItemInputType>>("foodList");
            Field(x => x.CreateAt);
        }
    }
}
