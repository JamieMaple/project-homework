using System;
using System.Threading.Tasks;
using System.Collections.Generic;

using DotNetCoreBackend.DAL;

namespace DotNetCoreBackend.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IFoodRepository _foodRepository;

        public OrderService(IOrderRepository orderRepository, IFoodRepository foodRepository)
        {
            _orderRepository = orderRepository;
            _foodRepository = foodRepository;
        }

        public async Task<bool> DispatchNewOrder(int roomId, int waiterId, List<FoodListItem> foodItemList)
        {
            try
            {
                var foods = await _foodRepository.GetFoodBySomeFoodItem(foodItemList);
                double sum = 0; foods.ForEach(food => sum += food.UnitPrice * food.Count); 
                var order = new Order
                {
                    RoomId = roomId,
                    WaiterId = waiterId,
                    FoodList = foods,
                    Status = OrderStatus.Created,
                    TotalPrice = sum,
                    CreateAt = DateTimeOffset.UtcNow.ToUnixTimeSeconds(),
                };
                await _orderRepository.DispatchOrder(order);
            }
            catch (Exception err)
            {
                Console.WriteLine(err);
            }

            return true;
        }

        public async Task<bool> DeleteOrderById(int id)
        {
            try
            {
                return await _orderRepository.DeleteOrderById(id);
            }
            catch (Exception err)
            {
                Console.WriteLine(err);
                return false;
            }
        }

        public async Task<List<Order>> GetOrderList(int offset, int limit)
        {
            try
            {
                return await _orderRepository.GetOrderList(offset, limit);
            }
            catch (Exception err)
            {
                Console.WriteLine(err);
                return null;
            }
        }

        /*
         * !!WARNING!!: NO UPDATE CODE FOR ORDER
         */
    }


    public interface IOrderService
    {
        Task<bool> DispatchNewOrder(int roomId, int waiterId, List<FoodListItem> foodItemList);
        Task<bool> DeleteOrderById(int id);
        Task<List<Order>> GetOrderList(int offset, int limit);
    }
}
