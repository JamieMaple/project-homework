using GraphQL;
using GraphQL.Types;
using GraphQL.Authorization;

using DotNetCoreBackend.Services;

namespace DotNetCoreBackend.GraphQLSchema
{
    public class BasicQuery : ObjectGraphType
    {
        public BasicQuery(
            IRoomService roomService,
            IFoodService foodService,
            IUserService userService
        )
        {
            FieldAsync<ListGraphType<RoomType>>("rooms", resolve: async _ => await roomService.GetAllRooms());

            FieldAsync<ListGraphType<FoodType>>("foods", resolve: async _ => await foodService.GetAllFoodWithOffsetAndLimit(0, 100))
                .AuthorizeWith("WaiterPolicy");

            FieldAsync<StringGraphType>("token", resolve: async _ =>
            {
                return await userService.Authentication("username", "password");
            });
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
