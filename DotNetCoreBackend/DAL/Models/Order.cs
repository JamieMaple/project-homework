using System.Collections.Generic;

namespace DotNetCoreBackend.DAL
{
    public enum OrderStatus {
        Created  = 1,
        Pending  = 2,
        Finished = 4
    }


    public class FoodListItem : Food
    {
        public int Count { get; set; }
    }


    public class Order
    {
        public int RoomId { get; set; }

        // different from Food class
        public List<FoodListItem> FoodList { get; set; }

        public long FinishAt { get; set; }

        public double TotalPrice { get; set; }

        public OrderStatus Status { get; set; }
    }
}
