using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Dapper.FastCrud;

namespace DotNetCoreBackend.DAL
{
    public class RoomRepository : BaseRepository, IRoomRepository
    {
        public RoomRepository(IConfiguration config) : base(config) { }

        public async Task<List<Room>> GetAllRooms()
        {
            using (var conn = Connection)
            {
                conn.Open();
                var rooms = await conn.FindAsync<Room>();
                return rooms.ToList();
            }
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

        public async Task<Room> ChangeRoomStatus(int roomId, RoomStatus status)
        {
            using (var conn = Connection)
            {
                conn.Open();
                var room = await conn.GetAsync(new Room { Id = roomId });
                var now = DateTimeOffset.UtcNow.ToUnixTimeSeconds();

                room.LastUpdateAt = now;
                room.Status = status;

                // history
                // var history = new RoomHisotry {  }

                await conn.UpdateAsync(room);
                return room;
            }
        }

        public async Task<RoomHistory> SaveRoomHistory(Room room, int userId)
        {
            var roomHistory = new RoomHistory {
                RoomId = room.Id,
                WaiterId = userId,
                Name = room.Name,
                Status = room.Status,
                CreateAt = DateTimeOffset.UtcNow.ToUnixTimeSeconds(),
            };
            using (var conn = Connection)
            {
                conn.Open();
                await conn.InsertAsync(roomHistory);
            }

            return roomHistory;
        }
    }

    public interface IRoomRepository
    {
        Task<List<Room>>GetAllRooms();
        Task<Room> ChangeRoomStatus(int roomId, RoomStatus status);
        Task<RoomHistory> SaveRoomHistory(Room room, int userId);
    }
}
