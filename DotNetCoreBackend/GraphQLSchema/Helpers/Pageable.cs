namespace DotNetCoreBackend.GraphQLSchema
{
    public class Pageable {
        public int Limit;
        public int Offset;

        public static Pageable defaultPageable ()
        {
            return new Pageable { Limit = 150, Offset = 0 };
        }
    }
}
