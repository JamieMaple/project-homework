using System;
using System.Security.Claims;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using GraphQL.Authorization;
using GraphQL.Validation;

using DotNetCoreBackend.Security;

namespace DotNetCoreBackend.GraphQLSchema
{
    public static class GraphQLExtensions
    {
        public static void AddGraphQLCustomTypeSupport(this IServiceCollection services)
        {

            services.AddSingleton<CategoryType>();

            services.AddSingleton<FoodInputType>();
            services.AddSingleton<FoodType>();
            services.AddSingleton<FoodQuery>();
            services.AddSingleton<FoodMutation>();

            services.AddSingleton<RoomType>();
            services.AddSingleton<RoomInputType>();
            services.AddSingleton<RoomStatusEnum>();
            services.AddSingleton<RoomQuery>();
            services.AddSingleton<RoomMutation>();

            services.AddSingleton<FoodListItemInputType>();
            services.AddSingleton<FoodListItemType>();
            services.AddSingleton<OrderType>();
            services.AddSingleton<OrderStatusType>();
            services.AddSingleton<OrderInputType>();
            services.AddSingleton<OrderQuery>();
            services.AddSingleton<OrderMutation>();

            services.AddSingleton<UserTypeEnum>();
            services.AddSingleton<UserType>();
            services.AddSingleton<UserInputType>();
            services.AddSingleton<UserQuery>();
            services.AddSingleton<UserMutation>();

            services.AddSingleton<BasicMutation>();
            services.AddSingleton<BasicQuery>();
            services.AddSingleton<BasicSchema>();

            services.AddSingleton<RootQuery>();
            services.AddSingleton<RootMutation>();
            services.AddSingleton<RootSchema>();
        }


        public static void AddGraphQLAuth(this IServiceCollection services)
        {
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.TryAddSingleton<IAuthorizationEvaluator, AuthorizationEvaluator>();
            services.AddTransient<IValidationRule, AuthorizationValidationRule>();

            services.TryAddSingleton(s =>
            {
                var authSettings = new AuthorizationSettings();

                authSettings.AddPolicy(Policy.WaiterPolicy, p => p.RequireClaim(ClaimTypes.Role, Role.WaiterRole, Role.AdminRole, Role.RootRole));
                authSettings.AddPolicy(Policy.AdminPolicy, p => p.RequireClaim(ClaimTypes.Role, Role.AdminRole, Role.RootRole));
                authSettings.AddPolicy(Policy.RootPolicy, p => p.RequireClaim(ClaimTypes.Role, Role.RootRole));

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
