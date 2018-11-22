using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Dapper.FastCrud;


namespace DotNetCoreBackend.DAL
{
    public class OrderRepository : BaseRepository, IOrderRepository
    {
        public OrderRepository(IConfiguration config) : base(config) {  }

        public async Task<bool> DispatchOrder(Order order)
        {
            using (var conn = Connection)
            {
                await conn.InsertAsync(order);
                return true;
            }
        }

/*
 *  TODO: curd
 */
    }

    public interface IOrderRepository
    {
        Task<bool> DispatchOrder(Order order);
    }
}
