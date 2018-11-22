using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
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

        public async Task<List<FoodListItem>> GetFoodBySomeFoodItem(List<FoodListItem> foodListItem)
        {
            var tasks = new List<Task<FoodListItem>>();
            var foodList = new List<FoodListItem>();
            using (var conn = Connection)
            {
                conn.Open();

                foreach (var food in foodListItem)
                {
                    var item = await conn.GetAsync(new FoodListItem { Id = food.Id });
                    item.Count = food.Count;
                    foodList.Add(item);
                }
            }

            return foodList.ToList();
        }

        public async Task<List<Category>> GetAllCategories()
        {
            using (var conn = Connection)
            {
                var result = await conn.FindAsync<Category>();

                return result.ToList();
            }
        }
        /*
         *  TODO: curd
         */
    }


    public interface IFoodRepository
    {
        Task<List<Food>> GetAllFoodWithOffsetAndLimit(int offset, int limit);
        Task<List<FoodListItem>> GetFoodBySomeFoodItem(List<FoodListItem> foodListItem);
        Task<List<Category>> GetAllCategories();
    }
}
