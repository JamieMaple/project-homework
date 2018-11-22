using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using Dapper.FastCrud;

namespace DotNetCoreBackend.DAL
{
    public class FoodRepository : BaseRepository, IFoodRepository
    {
        public FoodRepository(IConfiguration config) : base(config) { }

        public async Task<List<Food>> GetAllFoodWithOffsetAndLimit(int offset, int limit)
        {
            using (var conn = Connection)
            {
                conn.Open();
                var result = await conn.FindAsync<Food>(s => s.Skip(offset).Top(limit));
                return result.ToList();
            }
        }

        public async Task<List<Food>> GetFoodBySomeId(List<int> ids)
        {
            List<Food> foodList = new List<Food>();
            ids.ForEach(id => foodList.Append(new Food { Id = id }));
            using (var conn = Connection)
            {
                conn.Open();
                await conn.GetAsync(foodList);
            }

            return null;
        }

/*
 *  TODO: curd
 */
    }


    public interface IFoodRepository
    {
        Task<List<Food>> GetAllFoodWithOffsetAndLimit(int offset, int limit);
    }
}
