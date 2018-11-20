using GraphQL;
using GraphQL.Types;

using DotNetCoreBackend.Services;

namespace DotNetCoreBackend.GraphQLSchema
{
    public class BasicQuery : ObjectGraphType
    {
        public BasicQuery(
            IRoomService roomService,
            IFoodService foodService
        )
        {
            FieldAsync<ListGraphType<RoomType>>("rooms", resolve: async _ => await roomService.GetAllRooms());

            FieldAsync<ListGraphType<FoodType>>("foods", resolve: async _ => await foodService.GetAllFoodWithOffsetAndLimit(0, 30));
        }
    }


    public class BasicSchema : Schema
    {
        public BasicSchema(IDependencyResolver resolver)
        {
            Query = resolver.Resolve<BasicQuery>();
        }
    }
}
