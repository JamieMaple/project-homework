using GraphQL.Types;
using DotNetCoreBackend.DAL;

namespace DotNetCoreBackend.GraphQLSchema
{
    public class FoodType : ObjectGraphType<Food>
    {
        public FoodType()
        {
            Name = "Food";

            Field(x => x.Id);
            Field(x => x.Name);
            Field(x => x.UnitPrice);
        }
    }
}
