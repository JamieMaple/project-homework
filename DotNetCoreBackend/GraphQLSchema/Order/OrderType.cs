using GraphQL.Types;

using DotNetCoreBackend.DAL;

namespace DotNetCoreBackend.GraphQLSchema
{
    public class OrderFoodListInputType : InputObjectGraphType<Food>
    {
        public OrderFoodListInputType()
        {
            Field(x => x.Id);
            Field<IntGraphType>("count");
        }
    }

    public class OrderType : ObjectGraphType<Order>
    {
        public OrderType()
        {
            Field(x => x.Id);
        }
    }
    
}
