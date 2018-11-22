using GraphQL.Types;
using DotNetCoreBackend.DAL;

namespace DotNetCoreBackend.GraphQLSchema
{
    public class FoodInputType : InputObjectGraphType<FoodListItem>
    {
        public FoodInputType()
        {
            Name = "FoodInputType";

            Field(x => x.Id);
            Field(x => x.Name);
            Field(x => x.Count);
            Field(x => x.UnitPrice);
        }
    }
}
