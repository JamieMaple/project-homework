using System;
using System.Security.Claims;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using GraphQL.Authorization;
using GraphQL.Validation;

namespace DotNetCoreBackend
{
    public static class GraphQLAuthExtensions
    {
        public static void AddGraphQLAuth(this IServiceCollection services)
        {
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.TryAddSingleton<IAuthorizationEvaluator, AuthorizationEvaluator>();
            services.AddTransient<IValidationRule, AuthorizationValidationRule>();

            services.TryAddSingleton(s =>
            {
                var authSettings = new AuthorizationSettings();
                authSettings.AddPolicy("WaiterPolicy", p => p.RequireClaim(ClaimTypes.Role, "waiter"));
                authSettings.AddPolicy("AdminPolicy", p => p.RequireClaim(ClaimTypes.Role, "admin"));
                authSettings.AddPolicy("RootPolicy", p => p.RequireClaim(ClaimTypes.Role, "root"));
                return authSettings;
            });
        }
    }

    public class GraphQLSettings
    {
        public Func<HttpContext, Task<IProvideClaimsPrincipal>> BuildUserContext { get; set; }
        public object Root { get; set; }
        public List<IValidationRule> ValidationRules { get; } = new List<IValidationRule>();
    }

    public class GraphQLUserContext : IProvideClaimsPrincipal
    {
        public ClaimsPrincipal User { get; set; }
    }

    public static class GraphQLMiddlewareExtensions
    {
       
    }
}
