namespace DotNetCoreBackend.Models
{
    public enum RoomStatus {
        Idle = 0,
        Busy = 1
    }


    public class Room : Base
    {
        public string Name { get; set; }

        public int floor { get; set; }

        public RoomStatus status { get; set; }

        public long LastUpdateAt { get; set; }
    }
}
