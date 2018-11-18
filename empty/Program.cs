using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Builder;
using empty.Services;
using empty.DAL;
using Dapper.FastCrud;

namespace empty
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            System.Console.WriteLine(configuration.GetConnectionString("MyConnectionString"));
            Configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            // runtime gets called. add services
            services.AddMvc();
            services.AddScoped<ITodosService, TodosService>();
            services.AddTransient<ITodoRepository, TodoRepository>();
        }
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            }
            // http request pipline
            app.UseHttpsRedirection();
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
