using GraphQL.Types;
using DotNetCoreBackend.Services;

namespace DotNetCoreBackend.GraphQLSchema
{
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
