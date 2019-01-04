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

            FieldAsync<ListGraphType<FoodType>>(
                "foods",
                arguments: new QueryArguments(
                    new QueryArgument<IntGraphType> { Name = "limit" },
                    new QueryArgument<IntGraphType> { Name = "offset" }
                    ),
                resolve: async context =>
            {
                var page = new Pageable(context, 120);

                return await foodService.GetAllFoodWithOffsetAndLimit(page.Offset, page.Limit);
            });

            FieldAsync<ListGraphType<CategoryType>>("categories", resolve: async context =>
            {
                return await foodService.GetAllCategories();
            });
        }
    }
}
