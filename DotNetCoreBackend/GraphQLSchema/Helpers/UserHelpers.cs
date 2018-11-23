using System;
using System.Linq;
using System.Security.Claims;
using GraphQL;

namespace DotNetCoreBackend.GraphQLSchema
{
    public class UserHelpers
    {
        public static int GetUserIdFromContext(object uc)
        {
            var userContext = uc as GraphQLUserContext;
            if (userContext == null) throw new ExecutionError("please provide right user context");

            var claim = userContext.User.Claims.Where(c => c.Type == ClaimTypes.PrimarySid).FirstOrDefault();
            if (claim == null) throw new ExecutionError("cannot get right field from your token");

            try
            {
                return Convert.ToInt32(claim.Value);
            }
            catch(Exception)
            {
                throw new ExecutionError("error token claims");
            }
        }
    }
}
