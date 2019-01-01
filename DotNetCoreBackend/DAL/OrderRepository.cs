using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Dapper;
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
                return await GetList<Order>(offset, limit);
            }
        }

        public async Task<bool> ChangeOrderStatus(int orderId, OrderStatus status)
        {
            using (var conn = Connection)
            {
                long time = 0;
                if (status == OrderStatus.Finished)
                {
                    time = GetTime();
                }

                var sql = @"UPDATE `order` SET status=@Status, finish_at=@Time Where id=@Id";
                await conn.ExecuteAsync(sql, new { Id=orderId, Status=status, Time=time });

                return true;
            }
        }

/*
 * !!!!despired
 */
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
                return await Delete(id, "order");
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
        Task<bool> ChangeOrderStatus(int orderId, OrderStatus status);
    }
}
