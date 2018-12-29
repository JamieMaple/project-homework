using System;
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

        public async Task<List<Food>> GetAllFoodWithOffsetAndLimit(int offset, int limit)
        {
            try
            {
                return await _foodRepository.GetAllFoodWithOffsetAndLimit(offset, limit);
            }
            catch (Exception err)
            {
                Console.WriteLine(err);
                return null;
            }
        }

        public async Task<List<Category>> GetAllCategories()
        {
            try
            {
                return await _foodRepository.GetAllCategories();
            }
            catch (Exception err)
            {
                Console.WriteLine(err);
                return null;
            }
        }

        public async Task<bool> AddFood(Food food)
        {
            try
            {
                return await _foodRepository.AddFood(food);
            }
            catch (Exception err)
            {
                Console.WriteLine(err);
                return false;
            }
        }

        public async Task<bool> DeleteFoodById(int id)
        {
            try
            {
                var food = new Food { Id = id };
                return await _foodRepository.DeleteFood(food);
            }
            catch (Exception err)
            {
                Console.WriteLine(err);
                return false;
            }
        }

        public async Task<bool> UpdateFood(Food food)
        {
            try
            {
                return await _foodRepository.UpdateFood(food);
            }
            catch (Exception err)
            {
                Console.WriteLine(err);
                return false;
            }
        }
    }


    public interface IFoodService
    {
        Task<List<Food>> GetAllFoodWithOffsetAndLimit(int offset, int limit);
        Task<List<Category>> GetAllCategories();
        Task<bool> AddFood(Food food);
        Task<bool> DeleteFoodById(int foodId);
        Task<bool> UpdateFood(Food food);
    }
}
