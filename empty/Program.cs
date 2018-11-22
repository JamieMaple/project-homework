using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Builder;
using empty.Services;
using empty.DAL;
using Dapper.FastCrud;
using empty.Schema;
using GraphQL.Server.Ui.Playground;
using GraphQL.Server;
using GraphQL;
using GraphiQl;

namespace empty
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IHostingEnvironment env)
        {
            System.Console.WriteLine(env.ContentRootPath);
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            var configuration = builder.Build();
            System.Console.WriteLine(configuration.GetConnectionString("MyConnectionString"));
            Configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            // runtime gets called. add services
            services.AddSingleton<ITodosService, TodosService>();
            services.AddTransient<ITodoRepository, TodoRepository>();
            services.AddSingleton<TodoType>();
            services.AddSingleton<TodoInput>();
            services.AddSingleton<TodoQuery>();
            services.AddSingleton<TodoMutation>();
            services.AddSingleton<TodoSchema>();
            services.AddSingleton<IDependencyResolver>(s => new FuncDependencyResolver(s.GetRequiredService));
            services.AddGraphQL(options =>
                {
                    options.EnableMetrics = true;
                    options.ExposeExceptions = true;
                })
                .AddDataLoader();
            services.AddMvc();
        }
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseGraphQL<TodoSchema>("/graphql");
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            }
            // http request pipline
            app.UseGraphiQl("/graphiql", "/graphql");
            app.UseGraphQLPlayground(new GraphQLPlaygroundOptions{ Path = "/graphiql/playground", GraphQLEndPoint = "/graphql" });
            // app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
    public class Program
    {
        public static void Main(string[] args)
        {
            OrmConfiguration.DefaultDialect = SqlDialect.MySql;
            CreateWebHostBuilder(args).Build().Run();
        }
        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args).UseStartup<Startup>();
    }
}
