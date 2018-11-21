using Microsoft.Extensions.DependencyInjection;

namespace DotNetCoreBackend.DAL
{
    public static class RepositoryExtensions
    {
        public static void AddCustomRepositories(this IServiceCollection services)
        {
            services.AddSingleton<IRoomRepository, RoomRepository>();
            services.AddSingleton<IUserRepository, UserRepository>();
            services.AddSingleton<IOrderRepository, OrderRepository>();
            services.AddSingleton<IFoodRepository, FoodRepository>();
        }
    }
}
