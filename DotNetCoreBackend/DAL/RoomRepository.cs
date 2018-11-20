using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace DotNetCoreBackend.DAL
{
    public class RoomRepository : BaseRepository, IRoomRepository
    {
        public RoomRepository(IConfiguration config) : base(config) { }

        public async Task<List<Room>> GetAllRooms()
        {
            await Task.Delay(500);
            System.Console.WriteLine("here");
            return new List<Room>()
            {
                new Room { Id = 1, Name = "401", Status = RoomStatus.Busy, Floor = 4 },
                new Room { Id = 1, Name = "401", Status = RoomStatus.Busy, Floor = 4 },
                new Room { Id = 1, Name = "401", Status = RoomStatus.Busy, Floor = 4 },
                new Room { Id = 1, Name = "401", Status = RoomStatus.Busy, Floor = 4 },
                new Room { Id = 1, Name = "401", Status = RoomStatus.Busy, Floor = 4 },
            };
        }

        /*
         *  TODO: add a room
         */
        public bool AddRoom()
        {
            return false;
        }

        /*
         *  TODO: delete a room
         */
        public bool DeleteRoomById()
        {
            return false;
        }

        /*
         *  TODO: search for room
         */
        public List<Room> SearchRoom(int id)
        {
            return null;
        }

        public List<Room> SearchRoom(string name)
        {
            return null;
        }

        /*
         *  TODO: change Room
         */

        public bool ChangeRoomStatus()
        {
            return false;
        }

        public bool ChangeRoomName()
        {
            return false;
        }
    }

    public interface IRoomRepository
    {
        Task<List<Room>>GetAllRooms();
    }
}
