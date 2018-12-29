using GraphQL.Types;
using DotNetCoreBackend.DAL;

namespace DotNetCoreBackend.GraphQLSchema
{
    public class FoodInputType : InputObjectGraphType<Food>
    {
        public FoodInputType()
        {
            Name = "FoodInputType";

            Field(x => x.Name);
            Field(x => x.UnitPrice);
            Field(x => x.Image);
            Field(x => x.CategoryId);
        }
    }
}
