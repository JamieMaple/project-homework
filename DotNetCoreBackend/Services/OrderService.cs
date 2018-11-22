using System.Threading.Tasks;

using DotNetCoreBackend.DAL;

namespace DotNetCoreBackend.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<bool> CreateNewOrder()
        {
            await Task.Delay(300);
            return false;
        }
    }


    public interface IOrderService
    {
    }
}
