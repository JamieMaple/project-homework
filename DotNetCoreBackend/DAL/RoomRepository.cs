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

        public async Task<bool> AddRoom(Room room)
        {
            using (var conn = Connection)
            {
                await conn.InsertAsync(room);
            }
            return true;
        }

        public async Task<List<Room>> GetAllRooms()
        {
            using (var conn = Connection)
            {
                conn.Open();
                var rooms = await conn.FindAsync<Room>();
                return rooms.ToList();
            }
        }

        public async Task<bool> UpdateRoom(Room room)
        {
            using (var conn = Connection)
            {
                await conn.UpdateAsync(room);
            }
            return true;
        }

        public async Task<bool> DeleteRoomById(int id)
        {
            using (var conn = Connection)
            {
                await conn.DeleteAsync(new Room { Id = id });
            }
            return true;
        }

        public async Task<Room> ChangeRoomStatus(int roomId, RoomStatus status, int userId)
        {
            using (var conn = Connection)
            using (var transaction = conn.BeginTransaction())
            {
                conn.Open();
                var room = await conn.GetAsync(new Room { Id = roomId });
                var now = DateTimeOffset.UtcNow.ToUnixTimeSeconds();

                room.LastUpdateAt = now;
                room.Status = status;

                var roomHistory = NewRoomHistory(room, userId);

                await conn.UpdateAsync(room);
                await conn.InsertAsync(roomHistory);
                transaction.Commit();

                return room;
            }
        }

        public async Task<List<Room>> SearchRoom(string name)
        {
            using (var conn = Connection)
            {
                var room = new Room { Name = name };
                var result = await conn.FindAsync<Room>(s => s.Where($"{nameof(Room.Name):C}=@Name").WithParameters(room));
                return result.ToList();
            }
        }

        private async Task<RoomHistory> NewRoomHistory(Room room, int userId)
        {
            var roomHistory = new RoomHistory
            {
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
        Task<List<Room>> GetAllRooms();
        Task<bool> AddRoom(Room room);
        Task<bool> DeleteRoomById(int id);
        Task<Room> ChangeRoomStatus(int roomId, RoomStatus status, int userId);
        Task<bool> UpdateRoom(Room room);
    }
}
