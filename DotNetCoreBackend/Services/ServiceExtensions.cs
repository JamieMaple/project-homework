using Microsoft.Extensions.DependencyInjection;

namespace DotNetCoreBackend.Services
{
    public static class ServiceExtensions
    {
        public static void AddCustomServices(this IServiceCollection services)
        {
            services.AddSingleton<IRoomService, RoomService>();
            services.AddSingleton<IUserService, UserService>();
            services.AddSingleton<IOrderService, OrderService>();
            services.AddSingleton<IFoodService, FoodService>();
        }
    }
}
