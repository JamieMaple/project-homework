using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Dapper.FastCrud;

namespace DotNetCoreBackend.DAL
{
    public class OrderRepository : BaseRepository, IOrderRepository
    {
        public OrderRepository(IConfiguration config) : base(config) { }

        public async Task<bool> DispatchOrder(Order order)
        {
            using (var conn = Connection)
            {
                await conn.InsertAsync(order);
                return true;
            }
        }

        public async Task<List<Order>> GetOrderList(int offset, int limit)
        {
            using (var conn = Connection)
            {
                var result = await conn.FindAsync<Order>(s => s.Skip(offset).Top(limit));
                return result.ToList();
            }
        }

        public async Task<bool> ChangeOrder(Order order)
        {
            using (var conn = Connection)
            {
                await conn.UpdateAsync(order);
                return true;
            }
        }

        public async Task<bool> DeleteOrderById(int id)
        {
            using (var conn = Connection)
            {
                // TODO: delete to update deleteAt
                await conn.DeleteAsync(new Order { Id = id });
                return true;
            }
        }

        public async Task<bool> UpdateOrder(Order order)
        {
            using (var conn = Connection)
            {
                await conn.UpdateAsync(order);
                return true;
            }
        }
    }

    public interface IOrderRepository
    {
        Task<bool> DispatchOrder(Order order);
        Task<bool> DeleteOrderById(int id);
        Task<bool> UpdateOrder(Order order);
        Task<List<Order>> GetOrderList(int offset, int limit);
    }
}
