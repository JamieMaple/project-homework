using System.Collections.Generic;
using GraphQL.Types;
using GraphQL.Authorization;

using DotNetCoreBackend.DAL;
using DotNetCoreBackend.Services;
using DotNetCoreBackend.Security;

namespace DotNetCoreBackend.GraphQLSchema
{
    public class OrderMutation : ObjectGraphType
    {
        public OrderMutation(IOrderService orderService)
        {
            Name = "OrderMutation";
            Description = "这里主要包含了添加订单等功能";

            FieldAsync<BooleanGraphType>(
                "createOrder",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "roomId" },
                    new QueryArgument<NonNullGraphType<ListGraphType<FoodListItemInputType>>> { Name = "foodList" }
                ),
                resolve: async context =>
                {
                    int userId = UserHelpers.GetUserIdFromContext(context.UserContext);

                    var roomId = context.GetArgument<int>("roomId");
                    var foodList = context.GetArgument<List<FoodListItem>>("foodList");

                    return await orderService.DispatchNewOrder(roomId, userId, foodList);
                }
            ).AuthorizeWith(Policy.WaiterPolicy);

            // 订单原子操作，不开放修改接口，但可以更改订单状态
            FieldAsync<BooleanGraphType>(
                "changeOrderStatus",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "orderId" },
                    new QueryArgument<NonNullGraphType<OrderStatusType>> { Name = "status" }
                ),
                resolve: async context =>
                {
                    var orderId = context.GetArgument<int>("orderId");
                    var status = context.GetArgument<OrderStatus>("status");
                    return await orderService.ChangeOrderStatus(orderId, status);
                }).AuthorizeWith(Policy.AdminPolicy);

            FieldAsync<BooleanGraphType>(
                "deleteOrder",
                arguments: new QueryArguments(
                    new QueryArgument<IntGraphType> { Name = "orderId" }
                ),
                resolve: async context =>
                {
                    var orderId = context.GetArgument<int>("orderId");

                    return await orderService.DeleteOrderById(orderId);
                }
            ).AuthorizeWith(Policy.AdminPolicy);
        }
    }
}
