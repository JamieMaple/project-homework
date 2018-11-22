using GraphQL.Types;
using GraphQL.Authorization;

using DotNetCoreBackend.Services;

namespace DotNetCoreBackend.GraphQLSchema
{
    [GraphQLAuthorize(Policy = "WaiterPolicy")]
    public class FoodQuery : ObjectGraphType
    {
        public FoodQuery(IFoodService foodService)
        {
            Name = "FoodQuery";
            Description = "这里包含了有菜单";

            FieldAsync<ListGraphType<FoodType>>("foods", resolve: async context =>
            {
                return await foodService.GetAllFoodWithOffsetAndLimit(0, 120);
            });
            FieldAsync<ListGraphType<CategoryType>>("categories", resolve: async context =>
            {
                return await foodService.GetAllCategories();
            });
        }
    }
}
