using System.ComponentModel.DataAnnotations.Schema;

namespace DotNetCoreBackend.DAL
{
    public enum RoomStatus {
        Idle = 1,
        Busy = 2
    }

    [Table("room")]
    public class Room : Base
    {
        public string Name { get; set; }

        public int Floor { get; set; }

        public RoomStatus Status { get; set; }

        [Column("last_update_at")]
        public long LastUpdateAt { get; set; }
    }

    [Table("room_history")]
    public class RoomHisotry : Base
    {
        public string Name { get; set; }

        public int Floor { get; set; }

        [Column("revert_at")]
        public int revertAt { get; set; }
    }
}
