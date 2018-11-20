using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Dapper.FastCrud;
using GraphQL;
using GraphQL.Server;
using GraphiQl;
using GraphQL.Server.Ui.Playground;

using DotNetCoreBackend.Services;
using DotNetCoreBackend.DAL;
using DotNetCoreBackend.GraphQLSchema;

namespace DotNetCoreBackend
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IHostingEnvironment env)
        {
            Configuration = configuration;
            Env = env;
        }

        public IConfiguration Configuration { get; }
        private readonly IHostingEnvironment Env;

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            OrmConfiguration.DefaultDialect = SqlDialect.MySql;

            services.AddSingleton<IConfiguration>(Configuration);

            services.AddTransient<IRoomRepository, RoomRepository>();
            services.AddTransient<IFoodRepository, FoodRepository>();
            services.AddTransient<IUserRepository, UserRepository>();

            services.AddSingleton<IRoomService, RoomService>();
            services.AddSingleton<IUserService, UserService>();
            services.AddSingleton<IOrderService, OrderService>();
            services.AddSingleton<IFoodService, FoodService>();

            services.AddSingleton<IDependencyResolver>(s => new FuncDependencyResolver(s.GetRequiredService));
            services.AddGraphQL(options =>
                {
                    options.EnableMetrics = true;
                    options.ExposeExceptions = Env.IsDevelopment();
                })
                .AddDataLoader();

            services.AddSingleton<RoomStatusEnum>();
            services.AddSingleton<RoomType>();
            services.AddSingleton<RoomQuery>();
            services.AddSingleton<FoodType>();
            
            services.AddSingleton<BasicQuery>();
            services.AddSingleton<BasicSchema>();
            
            services.AddSingleton<FoodQuery>();
            services.AddSingleton<RootQuery>();
            services.AddSingleton<RootSchema>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            string entry = "/api/graphql";
            string adminEntry = "/admin/api/graphql";

            app.UseGraphQL<BasicSchema>(entry);
            app.UseGraphQL<RootSchema>(adminEntry);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseGraphiQl("/graphiql", entry);
                app.UseGraphQLPlayground(new GraphQLPlaygroundOptions { Path = "/graphiql/playground", GraphQLEndPoint = entry });

                // admin
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
