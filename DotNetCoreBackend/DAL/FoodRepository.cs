using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace DotNetCoreBackend.DAL
{
    public class FoodRepository : BaseRepository, IFoodRepository
    {
        public FoodRepository(IConfiguration config) : base(config) { }

        public async Task<List<Food>> GetAllFoodWithOffsetAndLimit(int offset, int limit)
        {
            await Task.Delay(500);
            return new List<Food>()
            {
                new Food { Id = 1, Name = "food-1", UnitPrice = 10.5 },
                new Food { Id = 2, Name = "food-2", UnitPrice = 20.2 },
                new Food { Id = 3, Name = "food-3", UnitPrice = 30.5 },
            };
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
