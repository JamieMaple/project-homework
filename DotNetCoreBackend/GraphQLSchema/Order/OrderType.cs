using GraphQL.Types;

using DotNetCoreBackend.DAL;

namespace DotNetCoreBackend.GraphQLSchema
{
    public class FoodListItemType : ObjectGraphType
    {
        public FoodListItemType()
        {
            Field<IntGraphType>("id");
            Field<IntGraphType>("count");
        }
    }

    public class OrderType : ObjectGraphType<Order>
    {
        public OrderType()
        {
            Field(x => x.Id);
            Field(x => x.RoomId);
            Field(x => x.WaiterId);
            Field<ListGraphType<FoodListItemType>>("foodList");
            Field(x => x.CreateAt);
        }
    }
}
