using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DotNetCoreBackend.DAL
{
    [Table("food")]
    public class Food : Base
    {
        [Key]
        public new int Id { get; set; }
        public string Name { get; set; }

        [Column("unit_price")]
        public double UnitPrice { get; set; }

        [Column("category")]
        public int CategoryId { get; set; }

        [Column("img_url")]
        public string Image { get; set; }

        public static string TableName()
        {
            return "food";
        }
    }
}
