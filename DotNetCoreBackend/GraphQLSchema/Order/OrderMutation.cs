using GraphQL.Types;

using DotNetCoreBackend.Services;

namespace DotNetCoreBackend.GraphQLSchema
{
    public class OrderMutatition : ObjectGraphType<OrderInputType>
    {
        public OrderMutatition(IOrderService orderService)
        {
            Field<BooleanGraphType>(
                "createOrder",
                arguments: new QueryArguments(
                    new QueryArgument<IntGraphType> { Name = "roomid" },
                    new QueryArgument<NonNullGraphType<FoodListItemInputType>> { Name = "foodList" }
                ),
                resolve: _ => false
            );
        }
    }
}
