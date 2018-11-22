using GraphQL.Types; 
using GraphQL.Authorization;

using DotNetCoreBackend.DAL;

namespace DotNetCoreBackend.GraphQLSchema
{
    public class FoodListItemInputType : InputObjectGraphType
    {
        public FoodListItemInputType()
        {
            Field<IntGraphType>("id");
            Field<IntGraphType>("count");
        }
    }
    
    public class OrderInputType : InputObjectGraphType<Order>
    {
        public OrderInputType()
        {
            Name = "OrderInputType";
            Field(x => x.RoomId);
            Field(x => x.WaiterId);
            Field<ListGraphType<FoodListItemInputType>>("foodList");
        }
    }
}
