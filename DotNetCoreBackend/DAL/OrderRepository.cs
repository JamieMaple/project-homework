using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Dapper.FastCrud;

namespace DotNetCoreBackend.DAL
{
    public class OrderRepository : BaseRepository, IOrderRepository
    {
        public OrderRepository(IConfiguration config) : base(config) {  }

/*
 *  TODO: curd
 */
        public async Task<List<Order>> GetOrderList()
        {
            await Task.Delay(100);
            return null;
        }

        public async Task<bool> DispatchOrder(Order order)
        {
            using (var conn = Connection)
            {
                await conn.InsertAsync(order);
                return true;
            }
        }

        public async Task<bool> ChangeOrder()
        {
            await Task.Delay(100);
            return false;
        }

        public async Task<bool> DeleteOrder()
        {
            await Task.Delay(100);
            return false;
        }

    }

    public interface IOrderRepository
    {
        Task<bool> DispatchOrder(Order order);
    }
}
