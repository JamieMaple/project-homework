using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Dapper;
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
                room.CreateAt = room.LastUpdateAt = GetTime();
                room.Status = RoomStatus.Idle;

                await conn.InsertAsync(room);

                return true;
            }
        }

        public async Task<List<Room>> GetAllRooms(int offset, int limit)
        {
            using (var conn = Connection)
            {
                conn.Open();
                return await GetList<Room>(offset, limit);
            }
        }

        public async Task<bool> UpdateRoom(Room room)
        {
            using (var conn = Connection)
            {
                var sql = @"UPDATE room SET name=@Name, floor=@Floor, status=@Status WHERE id=@Id";
                return await conn.ExecuteAsync(sql, room) > 0;
            }
        }

        public async Task<bool> DeleteRoomById(int id)
        {
            using (var conn = Connection)
            {
                return await Delete(id, "room");
            }
        }

        public async Task<Room> ChangeRoomStatus(int roomId, RoomStatus status, int userId)
        {
            using (var conn = Connection)
            using (var transaction = conn.BeginTransaction())
            {
                conn.Open();
                var room = await conn.GetAsync(new Room { Id = roomId });

                room.LastUpdateAt = GetTime();
                room.Status = status;

                var roomHistory = NewRoomHistory(room, userId);

                await conn.UpdateAsync(room);
                await conn.InsertAsync(roomHistory);
                transaction.Commit();

                return room;
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
                CreateAt = GetTime(),
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
        Task<List<Room>> GetAllRooms(int offset, int limit);
        Task<bool> AddRoom(Room room);
        Task<bool> DeleteRoomById(int id);
        Task<Room> ChangeRoomStatus(int roomId, RoomStatus status, int userId);
        Task<bool> UpdateRoom(Room room);
    }
}
