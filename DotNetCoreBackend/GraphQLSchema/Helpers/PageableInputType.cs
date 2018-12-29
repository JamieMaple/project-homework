using GraphQL.Types;

namespace DotNetCoreBackend.GraphQLSchema
{
    public class PageableInputType : InputObjectGraphType<Pageable>
    {
        public PageableInputType()
        {
            Field(x => x.Offset);
            Field(x => x.Limit);
        }
    } 
}
