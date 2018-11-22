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
    public class OrderMutatition : ObjectGraphType
    {
        public OrderMutatition(IOrderService orderService, IRoomService roomService)
        {
            Field<BooleanGraphType>(
                "createOrder",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "roomId" },
                    new QueryArgument<NonNullGraphType<ListGraphType<FoodListItemInputType>>> { Name = "foodList" }
                ),
                resolve: context => {
                    var userContext = context.UserContext as GraphQLUserContext;
                    var claim = userContext.User.Claims.Where(c => c.Type == ClaimTypes.PrimarySid).FirstOrDefault();
                    if (claim == null) throw new ExecutionError("cannot get right field from your token");

                    var roomId = context.GetArgument<int>("roomId");
                    var foodList = context.GetArgument<List<FoodListItem>>("foodList");
                    int userId = 0;

                    if (foodList.Count <= 0) throw new ExecutionError("must have some foods");

                    try
                    {
                        userId = Convert.ToInt32(claim.Value);
                    }
                    catch(Exception)
                    {
                        throw new ExecutionError("error token claims");
                    }

                    orderService.DispatchNewOrder(roomId, userId, foodList);

                    return true;
                }
            );
        }
    }
}
