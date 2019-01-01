using GraphQL.Types;
using DotNetCoreBackend.DAL;

namespace DotNetCoreBackend.GraphQLSchema
{
    public class UserTypeEnum : EnumerationGraphType<DotNetCoreBackend.DAL.UserType> {  }

    public class UserType : ObjectGraphType<User>
    {
        public UserType()
        {
            Name = "UserListItemType";
            Field(x => x.Id);
            Field(x => x.Username);
            Field<UserTypeEnum>("type");
        }
    }
}
