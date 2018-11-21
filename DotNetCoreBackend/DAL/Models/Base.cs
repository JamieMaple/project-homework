using System.ComponentModel.DataAnnotations.Schema;

namespace DotNetCoreBackend.DAL
{
    public class Base
    {
        public int Id { get; set; }

        [Column("create_at")]
        public long CreateAt { get; set; }

        [Column("delete_at")]
        public long DeleteAt { get; set; }
    }
}
