using System;
using System.Linq;
using System.Security.Claims;
using System.Collections.Generic;
using GraphQL;
using GraphQL.Types;

using DotNetCoreBackend.DAL;
using DotNetCoreBackend.Services;

namespace DotNetCoreBackend.GraphQLSchema
{
    public class OrderMutation : ObjectGraphType
    {
        public OrderMutation(IOrderService orderService, IRoomService roomService)
        {
            Name = "OrderMutation";
            Description = "这里主要包含了添加订单等功能";


            Field<BooleanGraphType>(
                "createOrder",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "roomId" },
                    new QueryArgument<NonNullGraphType<ListGraphType<FoodListItemInputType>>> { Name = "foodList" }
                ),
                resolve: context => {
                    int userId = UserHelpers.GetUserIdFromContext(context.UserContext);

                    var roomId = context.GetArgument<int>("roomId");
                    var foodList = context.GetArgument<List<FoodListItem>>("foodList");

                    orderService.DispatchNewOrder(roomId, userId, foodList);

                    return true;
                }
            );
        }
    }
}
