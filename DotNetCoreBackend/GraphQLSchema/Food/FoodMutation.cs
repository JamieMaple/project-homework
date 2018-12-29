using GraphQL.Types;

using DotNetCoreBackend.DAL;
using DotNetCoreBackend.Services;

namespace DotNetCoreBackend.GraphQLSchema
{
    public class FoodMutation : ObjectGraphType
    {
        public FoodMutation(IFoodService foodService)
        {
            Name = "foodMutation";
            Description = "所谓菜品修改相关";

            FieldAsync<BooleanGraphType>(
                "createFood",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<FoodInputType>> { Name = "food" }
                ),
                resolve: async context =>
                {
                    var food = context.GetArgument<Food>("food");

                    return foodService.AddFood(food);
                }
            );

            FieldAsync<BooleanGraphType>(
                "updateFood",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<FoodInputType>> { Name = "food" }
                ),
                resolve: async context =>
                {
                    var food = context.GetArgument<Food>("food");

                    return foodService.UpdateFood(food);
                }
            );

            FieldAsync<BooleanGraphType>(
                "deleteFood",
                arguments: new QueryArguments(
                    new QueryArgument<IntGraphType> { Name = "foodId" }
                ),
                resolve: async context =>
                {
                    var foodId = context.GetArgument<int>("foodId");

                    return foodService.DeleteFoodById(foodId);
                }
            );
        }
    }
}
