using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Builder;
using empty.Services;

namespace empty
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            // runtime gets called. add services
            services.AddMvc();
            services.AddSingleton<ITodosService, TodosService>();
        }
        public void Configure(IApplicationBuilder app)
        {
            // http request pipline
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }
        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args).UseStartup<Startup>();
    }
}
