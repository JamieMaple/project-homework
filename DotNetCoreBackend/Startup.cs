using System;
using System.Text;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using GraphQL;
using GraphiQl;
using GraphQL.Server;
using Dapper.FastCrud;
using GraphQL.Server.Ui.Playground;

using DotNetCoreBackend.DAL;
using DotNetCoreBackend.Services;
using DotNetCoreBackend.GraphQLSchema;

namespace DotNetCoreBackend
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.${env.EnvironmentName}.json", true, true)
                .AddEnvironmentVariables();
            var configuration = builder.Build();
            OrmConfiguration.DefaultDialect = SqlDialect.MySql;
            Configuration = configuration;
            Env = env;
        }

        public IConfiguration Configuration { get; }
        private readonly IHostingEnvironment Env;

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = Configuration["Jwt:Issuer"],
                        ValidAudience = Configuration["Jwt:Issuer"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"])),
                    };
                });

            services.AddGraphQLAuth();

            services.AddCustomRepositories();
            services.AddCustomServices();

            services.AddSingleton<IDependencyResolver>(s => new FuncDependencyResolver(s.GetRequiredService));
            services.AddGraphQL(options =>
                {
                    options.EnableMetrics = true;
                    options.ExposeExceptions = Env.IsDevelopment();
                })
                .AddDataLoader()
                .AddUserContextBuilder(ctx =>
                {
                    return new GraphQLUserContext
                    {
                        User = ctx.User
                    };
                });
            services.AddGraphQLCustomTypeSupport();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            string entry = "/api/graphql";
            string adminEntry = "/admin/api/graphql";

            app.UseAuthentication();

            // normal user and admin use different entry point
            app.UseGraphQL<BasicSchema>(entry);
            app.UseGraphQL<RootSchema>(adminEntry);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseGraphiQl("/graphiql", entry);
                app.UseGraphQLPlayground(new GraphQLPlaygroundOptions { Path = "/graphiql/playground", GraphQLEndPoint = entry });

                // admin
                app.UseGraphiQl("/admin/graphiql", adminEntry);
                app.UseGraphQLPlayground(new GraphQLPlaygroundOptions { Path = "/admin/graphiql/playground", GraphQLEndPoint = adminEntry });
            }
            else
            {
                // use for https
                app.UseHsts();
            }
        }
    }
}
