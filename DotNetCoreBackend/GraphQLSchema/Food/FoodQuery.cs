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
            FieldAsync<ListGraphType<FoodType>>("foods", resolve: async context =>
            {
                return await foodService.GetAllFoodWithOffsetAndLimit(0, 20);
            });
        }
    }
}
