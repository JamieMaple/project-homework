using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace DotNetCoreBackend.DAL
{
    public enum OrderStatus
    {
        Created = 1,
        Pending = 2,
        Finished = 4
    }

    [Table("food")]
    public class FoodListItem
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        [NotMapped]
        public int Count { get; set; }

        [Column("unit_price")]
        public double UnitPrice { get; set; }
    }

    [Table("order")]
    public class Order : Base
    {
        [Column("room_id")]
        public int RoomId { get; set; }

        [Column("waiter_id")]
        public int WaiterId { get; set; }

        // different from Food class
        [NotMapped]
        public List<FoodListItem> FoodList { get; set; }

        [Column("food_list")]
        public string _FoodList
        {
            get
            {
                return JsonConvert.SerializeObject(FoodList);
            }
            set
            {
                try
                {
                    FoodList = JsonConvert.DeserializeObject<List<FoodListItem>>(value);
                }
                catch (JsonException)
                {
                    System.Console.WriteLine("Error in food_list decoding");
                }
            }
        }

        [Column("finish_at")]
        public long FinishAt { get; set; }

        [Column("total_price")]
        public double TotalPrice { get; set; }

        public OrderStatus Status { get; set; }
    }
}
