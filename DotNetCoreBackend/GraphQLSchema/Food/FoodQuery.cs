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
                // 爬取数量过多, 限制数量
                return await foodService.GetAllFoodWithOffsetAndLimit(0, 150);
            });
            FieldAsync<ListGraphType<CategoryType>>("categories", resolve: async context =>
            {
                return await foodService.GetAllCategories();
            });
        }
    }
}
