using System.Threading.Tasks;
using System.Collections.Generic;

using DotNetCoreBackend.DAL;

namespace DotNetCoreBackend.Services
{
    public class FoodService : IFoodService
    {
        private readonly IFoodRepository _foodRepository;

        public FoodService(IFoodRepository foodRepository)
        {
            _foodRepository = foodRepository;
        }

        public Task<List<Food>> GetAllFoodWithOffsetAndLimit(int offset, int limit)
        {
            return _foodRepository.GetAllFoodWithOffsetAndLimit(offset, limit);
        }
    }


    public interface IFoodService
    {
        Task<List<Food>> GetAllFoodWithOffsetAndLimit(int offset, int limit);
    }
}


