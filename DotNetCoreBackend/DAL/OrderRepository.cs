using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace DotNetCoreBackend.DAL
{
    public class OrderRepository : BaseRepository
    {
        public OrderRepository(IConfiguration config) : base(config) {  }


        public async Task<bool> DispatchOrder()
        {
            // TODO: finishi dispatch order
            await Task.Delay(400);
            return false;
        }

/*
 *  TODO: curd
 */
    }
}
