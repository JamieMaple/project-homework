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
            Name = "query";

            Field<RoomQuery>("room", resolve: _ => new {});

            FieldAsync<ListGraphType<FoodType>>("food", resolve: async _ => await foodService.GetAllFoodWithOffsetAndLimit(0, 100))
                .AuthorizeWith("WaiterPolicy");

            Field<UserQuery>("user", resolve: _ => new {});
        }
    }

    public class BasicMutation : ObjectGraphType
    {
        public BasicMutation(IUserService userService)
        {
            Name = "mutataion";

            Field<UserMutation>("user", resolve: _ => new {});
        }
    }


    public class BasicSchema : Schema
    {
        public BasicSchema(IDependencyResolver resolver): base(resolver)
        {
            Query = resolver.Resolve<BasicQuery>();

            Mutation = resolver.Resolve<BasicMutation>();
        }
    }
}
