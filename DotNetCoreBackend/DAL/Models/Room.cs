namespace DotNetCoreBackend.DAL
{
    public enum RoomStatus {
        Idle = 1,
        Busy = 2
    }


    public class Room : Base
    {
        public string Name { get; set; }

        public int Floor { get; set; }

        public RoomStatus Status { get; set; }

        public long LastUpdateAt { get; set; }
    }
}
