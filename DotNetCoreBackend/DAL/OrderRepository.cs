using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace DotNetCoreBackend.DAL
{
    public class OrderRepository : BaseRepository, IOrderRepository
    {
        public OrderRepository(IConfiguration config) : base(config) {  }

        public async Task<bool> DispatchOrder(Order order)
        {
            // TODO: finishi dispatch order
            await Task.Delay(400);
            return false;
        }

/*
 *  TODO: curd
 */
    }

    public interface IOrderRepository
    {

    }
}
