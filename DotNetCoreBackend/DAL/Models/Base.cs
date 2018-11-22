using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DotNetCoreBackend.DAL
{
    public class Base
    {
        [Key]
        public int Id { get; set; }

        [Column("create_at")]
        public long CreateAt { get; set; }

        [Column("delete_at")]
        public long DeleteAt { get; set; }
    }
}
